FROM node:alpine

RUN apk add --no-cache bash

WORKDIR /app/src

COPY frontend/package.json .
RUN npm install

# webpack build
COPY frontend .
ENTRYPOINT npm run build-watch