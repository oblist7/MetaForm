# MetaForm

## Description
MetaForm is a full-stack web application for submitting, storing, listing, and searching web forms. The backend is built with C# and ASP.NET Core, while the frontend is developed using Vue.js. This project demonstrates good software architecture, API design, and UI usability.

A task for candidates for full-stack developer (C#, JavaScript). [Author](https://oblist7.github.io/)

## Features
- Dynamic form submission with validation
- RESTful API to store and retrieve form submissions
- UI for listing and searching submissions
- Packed frontend assets with Vite/Webpack
- Supports running via Docker and standalone mode

## Prerequisites

Make sure you have the following installed:
- [Docker](https://docs.docker.com/get-docker/)
- [Docker Compose](https://docs.docker.com/compose/install/)
- (Optional for local setup) Node.js and .NET SDK 9.0

## Run the Project with Docker

To build and start the project in detached mode, use:

```sh
docker-compose up --build -d
```

To stop the containers, use:

```sh
docker-compose down
```

The frontend will be available at: `http://localhost:8080/`
The backend API will run at: `http://localhost:5173/`

## Run Without Docker

If you prefer running the application locally without Docker, follow these steps:

### Backend (ASP.NET Core)
```sh
cd web-api
dotnet restore
DOTNET_ENVIRONMENT=Development dotnet run
```

### Frontend (Vue.js)
Edit `vue.config.js` to proxy API requests:

```js
module.exports = {
  devServer: {
    proxy: {
      '/api': {
        target: 'http://localhost:5173',
        changeOrigin: true,
      }
    }
  }
};
```

Then start the frontend:
```sh
cd vue-app
npm install
npm run dev
```

Now, open `http://localhost:8080/` in your browser.

## API Endpoints
- **POST** `/api/submissions` - Submit a new form entry
- **GET** `/api/submissions` - List all form entries
- **GET** `/api/submissions?query=value` - Search for submissions

### REST API Updates
- **POST** `/api/submissions` (with file upload support via `multipart/form-data`)
- **GET** `/api/files/{fileId}` (returns a signed URL for file download)

