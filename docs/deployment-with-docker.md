# Deploying with Docker

For my own setup I am hosting both the database (shared mysql DB image, also used with other projects) and the api in Docker on my Synology NAS. Personally this was the cheapest option for playing about, compared to for example hosting everything in Azure.

As I currently am not running any DevOps pipelines (this is planned for the future!) I will be manually building and deploying the image. And because I'm playing about with my own hobby projects (I was curious also) I've setup my own private Docker repository, again using my NAS. You are free to use the public available Docker hub of course!

Important: if you are hosting a seperate container (without Docker compose) for MySQL like I am, make sure they are both in the bridge network! I made the mistake of setting up the database in the host network, after which I had issues with access from the API to the DB.

## Building the image

As this is a multi-project solution, I've placed the Dockerfile in the API project and will be calling it from the project root, e.g. `/smart-meter-logger-backend/src`:

    docker build -f SmartMeterLogger.Api/Dockerfile -t smartmeter-logger-api . --no-cache

Flags:

- `-f` denotes the location of the Dockerfile
- `-t` is the name of the image
- `--no-cache` forces Docker to pull and create new layers without reusing, to prevent any caching issues.

## Running the image locally

To validate the image is correctly working, it can be run using the following command:

    docker run -it
        -e ASPNETCORE_ENVIRONMENT='{ENVIRONMENT}'
        -e MYSQLCONNSTR_SmartMeterLoggerContext='{CONNECTIONSTRING}'
        -p 5000:80
        smartmeter-logger-api:latest

Flags:

- `-i` activates interactive mode, in which we can check the application output
- `-t` provides a pseudo TTY terminal
- `-e: ASPNETCORE_ENVIRONMENT`: environment variable alerting dotnet to which environment is running
- `-e: MYSQLCONNSTR_SmartMeterLoggerContext`: environment variable for inserting the database connectionstring
- `-p` contains the port mapping, making port 80 (that de application starts up on) available in localhost on port 5000

## Pushing to Docker registry

After conforming everything is running as it should, the image is deployed to my personal Docker registry.

### Self-signed certificates and WSL

I'm using self-signed certificates (including CA) because my NAS isn't available outside my private network. Besides this, I'm running Docker from WSL, due to the license restrictions for Windows Docker. Due to this, Docker first threw this error when trying to push:

`x509: certificate signed by unknown authority`

The CA certificate was already installed on the Windows side, but WSL (Ubuntu) didn't know about it. Fixing this issue was very simple:

1.  Retrieve or download root CA certificate
2.  Copy the certificate from Windows to the ca directory

        cp /mnt/c/Temp/ca-cert.crt /usr/local/share/ca-certificates

3.  Let Ubuntu update ca certificates

        sudo update-ca-certificates

4.  If all has worked, you should find the ca certificate here: `/etc/ssl/certs`

### Tagging and pushing the image

First we need to tag the image

    docker tag {IMAGE ID} {[REGISTRYHOST/][USERNAME/]}/{NAME}:{TAG}

So for example:

    docker tag f499fde25e1e docker.nas.local/smartmeter-logger-api:latest

To validate if the image has correctly been taged, view the images and you should see the image taged:

| REPOSITORY                             | TAG    | IMAGE ID     |
| -------------------------------------- | ------ | ------------ |
| docker.nas.local/smartmeter-logger-api | latest | f499fde25e1e |

We can now push the image:

    docker push docker.nas.local/smartmeter-logger-api

To confirm all has gone well I can check my repository at `https://docker.nas.local/v2/_catalog` and it should show the new repository.

#### Setup Synology NAS

I won't go into the installation of a private repository as there are pleny of [tutorials](https://dev.to/kedzior_io/setup-a-docker-registry-on-synolgy-aia). But I wan't to point out 1 important step, the registration of the repository in the Synology Container Manager. I first tried adding the url like this:

`https://docker.nas.local/v2`

This does NOT work. In the logs of the repository container, you will see the Container Manager trying various urls with both v1 and v2 endpoints. Therefore the V2 part must NOT be part of the registered url. Instead the correct way is like this:

`https://docker.nas.local`

After reloading the Registry page you should now see your images show.

For more info on the repository endpoints, check the [Docker API spec](https://docs.docker.com/registry/spec/api/#detail).

### Self-signed certificates

If you use self-signed certificates (including CA), you need to make Synology recognize it as a valid certificate in the same way we did for WSL. If not you can't download the image from the repository and get vague error messages.

1. SSH into your NAS (enable SSH through the Control Panel)
2. Copy CA cert ending in `.crt` to the directory `/var/db/ca-certificates` (TIP: you can access the NAS file directory!)
3. Execute the script provided by synology: update-ca-certificates.sh
4. Reboot entire NAS.

After rebooting Docker should allow you to get the image from the repository.

## Deploying container on Synology NAS

This section is only usefull if you are trying to deploy the or an image to Docker on your Synology NAS.

### File station

Currently the application does not use any persistant data so no need to setup any directories

### Reverse proxy

1. Open Control Panel --> Login Portal
2. Click on Advanced --> Reverse Proxy --> Create
3. Fill in the following and save:

| Category    | Setting     | Value                           |
| ----------- | ----------- | ------------------------------- |
| General     | Name        | Smartmeter Logger API           |
| Source      | Protocol    | HTTPS                           |
| Source      | Hostname    | smartmeter-logger-api.nas.local |
| Source      | Port        | 443                             |
| Source      | Enable HSTS | Yes                             |
| Destination | Protocol    | HTTP                            |
| Destination | Hostname    | localhost                       |
| Destination | Port        | 9500                            |

### Custom network

For the application to connect to the MySQL database, we need to make sure they are both on the same network. I.e. host with non-blocking ports OR a custom bridge network. I've chosen to use the custom-bridge network option which I can also use for other projects.

As for the connectionstring, you can use the database container name as host this way.

### Deploy image

1. Open Control Panel --> Task Scheduler
2. Click Create --> Scheduled Task --> User-defined script
3. Fill in the following in the General tab:

| Setting | Value                         |
| ------- | ----------------------------- |
| Task    | Install Smartmeter Logger API |
| User    | root                          |
| Enabled | No                            |

4.  Open the Schedule tab
5.  Select `Run on the following date`, don't change the other settings
6.  Open the Task Settings tab
7.  Enable the `Send run details by email` setting and enter your e-mailaddress
8.  Enter the following User-defined script:

        docker run -d --name=smartmeter-logger-api \
        -e ASPNETCORE_ENVIRONMENT='{ENVIRONMENT}' \
        -e MYSQLCONNSTR_SmartMeterLoggerContext='{CONNECTIONSTRING}' \
        -p 9500:80 \
        --net=custom-bridge
        --restart=always \
        docker.nas.local/smartmeter-logger-api:latest

9.  Click OK, aknowledge the warning and enter your password
10. Right-click the new task and click Run.

The task will now deploy the image using the user-defined script. If all goes well you should see the container show in the Container Manager.
