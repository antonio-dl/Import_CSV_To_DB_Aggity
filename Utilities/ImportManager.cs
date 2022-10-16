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
            var csvText = File.ReadAllLines(pathToCSV);
            var csvDT = ParseToDataTable(csvText,separator);

            SqlBulkCopy objbulk = new SqlBulkCopy(_dbconnection);
            //assigning Destination table name    
            objbulk.DestinationTableName = DestinationTable;
            //Mapping Table column    
            foreach (DataColumn column in csvDT.Columns)
                objbulk.ColumnMappings.Add(column.ColumnName,column.ColumnName);
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

        public DataTable ParseToDataTable(string[] csvText, char separator)
        {
            //Creating object of datatable  
            DataTable tblcsv = new DataTable();

            //creating columns  
            CreateColumns(tblcsv, csvText[0],separator);
            foreach (string csvRow in csvText[1..])
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

        //Function to Insert Records  
    }
}