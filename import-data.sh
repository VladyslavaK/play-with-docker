#wait for the SQL Server to come up
sleep 5s
#run the setup script to create the DB and the schema in the DB

echo 'db seed started'
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Alaska2017 -d master -i setup.sql