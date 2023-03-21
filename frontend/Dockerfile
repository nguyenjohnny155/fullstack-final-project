
#FROM node:16-alpine as builder
#WORKDIR /app
#COPY ./nginx.conf /nginx.conf
#COPY package*.json /app/
#RUN npm install -g pnpm
#RUN pnpm i

#COPY ./ /app/
#RUN pnpm build

#FROM nginx:latest
#ENV NODE_ENV production
#COPY --from=builder /app/build /usr/share/nginx/html

#new
#COPY --from=builder /nginx.conf /etc/nginx/conf.d/default.conf

#CMD ["nginx", "-g", "daemon off;"]

FROM node:12.2.0-alpine as build

# can also say /usr/app/...
WORKDIR /app

# copy the react app to the container
COPY . /app/

# prepare the container for building react
RUN npm install --silent
RUN npm install react-scripts@3.0.1 -g --silent

RUN npm run build

# prepare nginx
FROM nginx:1.16.0-alpine
COPY --from=build /app/build /usr/share/nginx/html
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d

# fire up nginx
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]