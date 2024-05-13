# ASP .NET Rest API endpoint shopping application
------------------------------------------

## Setup
- Start Docker engine (f.e. docker desktop)
- Start Docker image with MS SQL database (in root dir)
```bash
docker-compose up
```
- Open second command line
- Init SQL server (only once)
```bash
docker ps
choose docker
docker exec -it <container_hash> /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Heslo.123
```
- Create the database (only once)
```SQL
CREATE DATABASE shop_database
GO
```
- Move to `api` folder
- Init database with schema (only once - after execution, you can leave DB terminal)
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
