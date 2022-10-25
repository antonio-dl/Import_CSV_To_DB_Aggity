using System.Data;
using System.Data.SqlClient;

namespace Utilities

{
    public class ImportManager
    {
        private SqlConnection _dbconnection;
        public ImportManager( string destinationTable, string connectionString)
        {
            DestinationTable = destinationTable ?? throw new ArgumentNullException(nameof(destinationTable));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

            _dbconnection = new SqlConnection(ConnectionString);
        }

        public string ConnectionString { get; }
        public string DestinationTable { get; private set; }
        public void ImportCSVToDatabase(string pathToCSV, char separator)
        {
            var csvDT = ParseToDataTable(pathToCSV, separator);
            ImportCSVToDatabase(csvDT);


        }

        public void ImportCSVToDatabase(DataTable csvDT)
        {
            SqlBulkCopy objbulk = new SqlBulkCopy(_dbconnection);
            //assigning Destination table name    
            objbulk.DestinationTableName = DestinationTable;
            //Mapping Table column    
            foreach (DataColumn column in csvDT.Columns)
                objbulk.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            //inserting Datatable Records to DataBase    
            _dbconnection.Open();
            objbulk.WriteToServer(csvDT);
            _dbconnection.Close();
        }

        private void CreateColumns(DataTable tblcsv, string header, char separator)
        {
            string[] columnsNames = header.Split(separator);
            foreach (var columnName in columnsNames)
                tblcsv.Columns.Add(columnName);
        }

        public DataTable ParseToDataTable(string pathToCSV, char separator)
        {
            var csvTextLines = File.ReadAllLines(pathToCSV);
            //Creating object of datatable  
            DataTable tblcsv = new DataTable();

            //creating columns  
            CreateColumns(tblcsv, csvTextLines[0],separator);
            foreach (string csvRow in csvTextLines[1..])
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    //Adding each row into datatable  
                    tblcsv.Rows.Add();
                    int count = 0;
                    foreach (string FileRec in csvRow.Split(separator))
                    {
                        tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                        count++;
                    }
                }
            }
            return tblcsv;
        }

        public void CreateTable(DataTable dataTable)
        {
            TableCreator tc = new TableCreator(this.DestinationTable, this.ConnectionString);

            tc.CreateTable(dataTable);
        }

    }
}