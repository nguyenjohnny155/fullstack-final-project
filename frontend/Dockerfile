#/*
# ==== CONFIGURE =====
#FROM node:18-slim as build-stage
#RUN npm install -g pnpm

#WORKDIR /app
#COPY ./nginx.conf /nginx.conf
#COPY package*.json /app/


#RUN pnpm install
#COPY ./ /app/

#RUN pnpm build

#FROM nginx:latest
#COPY --from=build-stage /app/build/ /usr/share/nginx/html
#COPY --from=build-stage /nginx.conf /etc/nginx/conf.d/default.conf
FROM node:16-alpine as builder
WORKDIR /app
COPY . .
RUN npm install -g pnpm
RUN pnpm i
RUN pnpm build

FROM nginx
ENV NODE_ENV production
COPY --from=builder /app/build /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

