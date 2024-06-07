FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD="Heslo.123"

COPY init-database.sql /usr/src/app/init-database.sql
COPY init-database.sh /usr/src/app/init-database.sh

ARG INIT_DATABASE=false

CMD if [ "$INIT_DATABASE" = "true" ]; then /usr/src/app/init-database.sh; fi & /opt/mssql/bin/sqlservr
