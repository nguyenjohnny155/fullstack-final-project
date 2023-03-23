Hi Professor,

My application at the moment is only able to communicate between
frontend and backend via developer mode only. 

I ran into a bug during the Docker Container setup process that disabled 
the frontend and backend containers from being able to send
API requests/responses to each other. I tried to debug the problem 
for several days prior to submitting the final project, but 
unfortunately I ran out of time as I had to allocate time to 
finish projects in other classes.

Currently in my application, Docker can still be used to create 
both the frontend and backend containers via the command in the root directory:

> docker-compose up --no-cache

The resulting output will generate the images for both frontend and backend. Their respective IPs are:

frontend: http://localhost:3000/Home

backend: http://localhost:5038/api/...


DATABASE (DEVELOPER MODE ONLY): 
    The database that the backend uses is an memory database called DBContext.
This context utilizes EntityFramework for querying datatables. The seeding process
was not added, meaning everytime the application is recompiled then run, it is required
by us to manually append data to the Shop data table.  To append data to the Shop Data Table, 
please open Postman or localhost:5038/swagger/index.html and POST the following OBJECTS individually:

VERB: POST
IP: localhost:5038/api/Shop
SETTINGS: Body -> raw -> JSON
JSON OBJECTS: 

{
  "id": 0,
  "itemName": "PhobGCC 2.0.2 Controller",
  "itemBasePrice": 199.99,
  "rating": 4.5,
  "numReviews": 2274,
  "itemAddOns": [
    {
      "id": 0,
      "name": "Mouseclick Z",
      "price": 10.00
    }
  ],
  "s3BaseUrl": "s3://webdev-final-project/budget-phobgcc-2.0.2-controller-black.png"
}

{
  "id": 0,
  "itemName": "Custom Emerald Green Buttons",
  "itemBasePrice": 40.00,
  "rating": 5,
  "numReviews": 743,
  "itemAddOns": [
  ],
  "s3BaseUrl": "s3://webdev-final-project/gcc-custom-buttons-emerald-green.png"
  
}

{
  "id": 0,
  "itemName": "GCC Paracords",
  "itemBasePrice": 40.00,
  "rating": 4.4,
  "numReviews": 324,
  "itemAddOns": [

    {
      "id": 0,
      "name": "6ft",
      "price": 0.00
    },

    {
      "id": 0,
      "name": "12ft",
      "price": 15.00
    }
  ],
  "s3BaseUrl": "s3://webdev-final-project/gcc-custom-paracord-black.png"
  
}


{
  "id": 0,
  "itemName": "GCC Black Paracord",
  "itemBasePrice": 40.00,
  "rating": 3.5,
  "numReviews": 324,
  "itemAddOns": [

    {
      "id": 0,
      "name": "6ft",
      "price": 0.00
    },

    {
      "id": 0,
      "name": "12ft",
      "price": 15.00
    }
  ],
  "s3BaseUrl": "s3://webdev-final-project/gcc-custom-paracord-black.png"
  
}

{
  "id": 0,
  "itemName": "PhobGCC 2.0.2 Motherboard",
  "itemBasePrice": 119.99,
  "rating": 5.0,
  "numReviews": 8732,
  "itemAddOns": [

    {
      "id": 0,
      "name": "DIY Kit",
      "price": 20.00
    },

    {
      "id": 0,
      "name": "Presoldered",
      "price": 0
    }
  ],
  "s3BaseUrl": "s3://webdev-final-project/phobgcc-2.0.2-motherboard-only.png"
  
}
Installation guide:


