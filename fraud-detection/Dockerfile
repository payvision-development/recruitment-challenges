# specify the node base image with your desired version node:<version>
FROM node:10


ADD package.json /app/

WORKDIR /app

RUN npm install

ADD . /app

CMD ["npm", "test"]