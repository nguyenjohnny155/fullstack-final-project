Hi Professor,

My application at the moment is only able to communicate between
frontend and backend via developer mode only. Please feel 
free to message me directly if you any questions regarding
this application.

I ran into a bug during the Docker Container setup process that disabled 
the frontend and backend containers from being able to send
API requests/responses to each other. I tried to debug the problem 
for several days prior to submitting the final project, but 
unfortunately I ran out of time as I had to allocate time to 
finish projects in other classes.

Currently in my application, Docker can still be used to create 
both the frontend and backend containers via the command in the root directory:

$ docker-compose up --no-cache

The resulting output will generate the images for both frontend and backend. Their respective IPs are:

frontend: http://localhost:3000/Home

backend: http://localhost:5038/api/...


DATABASE: 
    The database that the backend uses is an memory database called DBContext.
This context utilizes EntityFramework for querying datatables. The seeding process
was not added, meaning everytime the application is recompiled then run, it is required
by us to manually append data to the Shop data table.  To append data to the Shop Data Table, 
please open Postman or localhost:5038/swagger/index.html and POST the following JSON OBJECTS 
individually found in the ShopDataObjects.txt file.

INSTALLATION GUIDE:
$ git clone https://github.com/nguyenjohnny155/fullstack-final-project.git
enter root directory

RUNNING APP VIA PRODUCTION MODE (WITH DOCKER):
$ docker-compose up 
frontend IP: http://localhost:3000/Home
backend IP (Accessible via Postman): http://localhost:5038/api/...

RUNNING APP VIA DEVELOPER MODE (NO DOCKER):
enter frontend directory 
$ sudo apt-install npm
$ sudo npm install n -g
$ sudo n stable
# get in the frontend directory
$ pnpm i
$ pnpm start 
Accessible at localhost:3000/Home

enter backend directory
$ declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /etc/os-release | tr -d '"'; fi)
$ wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
$ sudo dpkg -i packages-microsoft-prod.deb
$ rm packages-microsoft-prod.deb
$ sudo apt update
$ sudo apt install dotnet-sdk-7.0
$ sudo apt update
$ sudo apt upgrade dotnet-sdk-7.0
$ dotnet run
Accessible at localhost:5038/swagger/index.html
in postman, POST the following JSON objects found in the ShopDataObjects.txt file.
refresh http://localhost:3000/Home

















