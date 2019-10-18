# REST API implementation

This is a Game of Thrones inspired REST API game. You are responsible to create the engine of the game.

## Your tasks

1. Implement the endpoints in **./src/api.js** file with the most suitable code for players and objects management REST API. You will find detailed instructions in this file.
2. Write some tests for your code. Use test folder for this purpose.
3. Answer all commented questions you find in the code.

**Bonus:**

1. Include a postman collection in utils folder to test the app.
2. Add basic authentication to /api path.

## How to run the application using a local server

To run the project, open a terminal and execute the following command from project root path:

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
