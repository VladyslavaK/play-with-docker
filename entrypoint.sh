   #!/bin/bash
   #start SQL Server
   sh -c " 
   echo 'Starting setup script'

   #run the setup script to create the DB and the schema in the DB
    exec ./import-data.sh

    echo 'Finished setup script'
    exit
    " & 
    exec /opt/mssql/bin/sqlservr