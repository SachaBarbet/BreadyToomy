# Bready Toomy

[Database diagram](https://dbdiagram.io/d/BreadyToomys-65dd997f5cd0412774e58f40)


## Install database (Recommended)
- Install docker
- Run the following command to create a postgresql container
```bash
docker run --name postgredb -e POSTGRES_PASSWORD=12345 -d -p 5432:5432 postgres
```

### Optional (If database connection is not working)
- Install postgresql odbc https://www.postgresql.org/ftp/odbc/releases/REL-16_00_0004/
- Add a new system DSN in Visual Studio with the following parameters; Tools -> Connect to a Database
- Data source: ODBC
- Use connection string -> Generate button -> Machine Datasource -> New -> System

Connection parameters:
- Type of data source: PostgreSQL ANSIx64 (PostgreSQL30) (Need odbc to be installed)
- Name: BreadyToomy (as you like)
- Server: localhost
- Port: 5432
- Database: postgres
- User: postgres
- Password: 12345 (same as POSTGRES_PASSWORD in the docker command)

## Authors
- [@SachaBarbet](https://github.com/SachaBarbet/)
- [@SajedehAdelia](https://github.com/SajedehAdelia)