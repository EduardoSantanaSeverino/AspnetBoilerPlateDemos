# Build App
FROM node:14.15.0 as build-env
WORKDIR /app
COPY package.json /app
RUN npm cache verify
RUN npm install
COPY . /app
ARG BUILD_NUMBER
RUN sed -i "s/%BUILD_NUMBER%/${BUILD_NUMBER}/" /app/src/environments/environment.prod.ts

FROM build-env as testrunner
CMD ["npm", "run", "test"]

ARG BUILD_TARGET="dev-deploy"
FROM build-env as build
RUN npm run ${BUILD_TARGET}

FROM nginx as runtime
COPY --from=build /app/dist/OTHER-Web /usr/share/nginx/html
COPY /nginx.conf  /etc/nginx/conf.d/default.conf
