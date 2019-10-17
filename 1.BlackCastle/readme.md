# REST API implementation

This is a Game of Thrones inspired REST API game. You are responsible to create the eng

## Your tasks

1. Complete commented endpoints from api.js file with the most suitable code for a player management CRUD RESTful API.
2. Write some tests for your code.
3. Answer all commented questions you finde in the code.
4. Add basic authentication to /api path.

**Bonus:** include a postman collection in utils folder to test the app.

## How to run the application using a local server

Run the following command in your terminal from project root path:

Install dependencies

> yarn

Start a local server

> yarn start

A local server will start on port 8080.

> http://localhost:8080

## How to run the application using Docker

Build the image:

> docker build -t <your username>/payvision-frontend-blackcastle .

Run the image on localhost port 8081:

> docker run -p 8081:8080 -d <your username>/payvision-frontend-blackcastle

Enter the container:

> docker exec -it <container id> sh

Print logs:

> docker logs <container id>
> docker logs -f --tail 10 <container id>
