#run the setup script to create the DB and the schema in the DB
#do this in a loop because the timing for when the SQL instance is ready is indeterminate
for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S mssql -U sa -P AreY0uD0neW1thCW! -d master -i /create.sql
    if [ $? -eq 0 ]
    then
        echo "create.sql completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done
