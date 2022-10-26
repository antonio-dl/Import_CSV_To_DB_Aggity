using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Utilities
{
    internal class TableCreator
    {
        public TableCreator(string destinationTable, string connectionString)
        {
            DestinationTable = destinationTable;
            ConnectionString = connectionString;
        }

        public string DestinationTable { get; }
        public string ConnectionString { get; }



        private string CreateTableSQL(DataTable table)
        {
            string sqlsc;
            sqlsc = "CREATE TABLE " + DestinationTable + "(";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "\n [" + table.Columns[i].ColumnName + "] ";
                string columnType = table.Columns[i].DataType.ToString();
                switch (columnType)
                {
                    case "System.Int32":
                        sqlsc += " int ";
                        break;
                    case "System.Int64":
                        sqlsc += " bigint ";
                        break;
                    case "System.Int16":
                        sqlsc += " smallint";
                        break;
                    case "System.Byte":
                        sqlsc += " tinyint";
                        break;
                    case "System.Decimal":
                        sqlsc += " decimal ";
                        break;
                    case "System.DateTime":
                        sqlsc += " datetime ";
                        break;
                    case "System.String":
                    default:
                        sqlsc += string.Format(" nvarchar({0}) ", table.Columns[i].MaxLength == -1 ? "max" : table.Columns[i].MaxLength.ToString());
                        break;
                }
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }
        public void CreateTable(DataTable dt)
        {
            var sqlCmd = CreateTableSQL(dt);

            Console.WriteLine(sqlCmd);
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private String NetType2SqlType(String netType, int maxLength)
        {
            String sqlType = "";

            // Map the .NET type to the data source type.
            // This is not perfect because mappings are not always one-to-one.
            switch (netType)
            {
                case "System.Boolean":
                    sqlType = "[bit]";
                    break;
                case "System.Byte":
                    sqlType = "[tinyint]";
                    break;
                case "System.Int16":
                    sqlType = "[smallint]";
                    break;
                case "System.Int32":
                    sqlType = "[int]";
                    break;
                case "System.Int64":
                    sqlType = "[bigint]";
                    break;
                case "System.Byte[]":
                    sqlType = "[binary]";
                    break;
                case "System.Char[]":
                    sqlType = "[nchar] (" + maxLength + ")";
                    break;
                case "System.String":
                    if (maxLength == 0x3FFFFFFF)
                        sqlType = "[ntext]";
                    else
                        sqlType = "[nvarchar] (" + maxLength + ")";
                    break;
                case "System.Single":
                    sqlType = "[real]";
                    break;
                case "System.Double":
                    sqlType = "[float]";
                    break;
                case "System.Decimal":
                    sqlType = "[decimal]";
                    break;
                case "System.DateTime":
                    sqlType = "[datetime]";
                    break;
                case "System.Guid":
                    sqlType = "[uniqueidentifier]";
                    break;
                case "System.Object":
                    sqlType = "[sql_variant]";
                    break;
            }

            return sqlType;
        }
    }
}