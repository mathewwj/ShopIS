#!/bin/bash
sleep 5s

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Heslo.123 -d master -i /usr/src/app/init-database.sql
