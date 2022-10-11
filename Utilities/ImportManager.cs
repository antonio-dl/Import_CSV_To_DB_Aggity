using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Utilities

{
    public class ImportManager
    {
        public string ConnectionString { get; }
        public char Separator { get; set; } = ',';
        private SqlConnection _dbconnection;
        private string CSVPath { get; set; }
        public string DestinationTable { get; private set; }

        public ImportManager(string cSVPath, char separator, string destinationTable, string connectionString)
        {
            CSVPath = cSVPath ?? throw new ArgumentNullException(nameof(cSVPath));
            Separator = separator;
            DestinationTable = destinationTable ?? throw new ArgumentNullException(nameof(destinationTable));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

            _dbconnection = new SqlConnection(ConnectionString);
        }

        public void ImportCSVToDatabase(string pathToCSV)
        {
            var csvText = File.ReadAllLines(pathToCSV);
            var csvDT = ParseToDataTable(csvText);

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

        private DataTable ParseToDataTable(string[] csvText)
        {
            //Creating object of datatable  
            DataTable tblcsv = new DataTable();

            //creating columns  
            CreateColumns(tblcsv, csvText[0]);
            foreach (string csvRow in csvText[1..])
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    //Adding each row into datatable  
                    tblcsv.Rows.Add();
                    int count = 0;
                    foreach (string FileRec in csvRow.Split(','))
                    {
                        tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                        count++;
                    }
                }
            }
            return tblcsv;
        }

        //Function to Insert Records  
   

        private void CreateColumns(DataTable tblcsv, string v)
        {
            string[] columnsNames = v.Split(Separator);
            foreach (var columnName in columnsNames)
                tblcsv.Columns.Add(columnName);
        }
    }
}