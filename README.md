# ASP .NET Rest API endpoint shopping application
------------------------------------------

## Setup
- Start Docker engine (f.e. docker desktop)
- Start Docker image with MS SQL database (in root dir)
```bash
docker-compose up
```
- Open second command line
- Move to `api` folder
- Init database with schema (only once)
```bash
dotnet ef database update
```
- Start C# application (`--init-data=false` or no param if you don't wish to seed the DB with sample data)
```bash
dotnet run -- --init-data=true
```

## Ports
**Swagger port**
```
http://localhost:5263/swagger/index.html
```
**Raw API endpoints location**:
```
http://localhost:5263/api/*
```
