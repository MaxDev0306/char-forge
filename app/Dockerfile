FROM node:alpine

WORKDIR /app

COPY . .
COPY ./package.json ./package.json

RUN npm i

CMD ["npm run dev"]