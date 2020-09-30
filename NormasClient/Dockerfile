### STAGE 1: Build ###
FROM node:12.7-alpine AS build
WORKDIR /app
COPY package.json /app
RUN npm install --silent
COPY . .
RUN npm run build:prod

### STAGE 2: Run ###
FROM nginx:1.17.1-alpine
VOLUME /var/cache/nginx
COPY --from=build app/dist/NormasClient /usr/share/nginx/html
COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf
