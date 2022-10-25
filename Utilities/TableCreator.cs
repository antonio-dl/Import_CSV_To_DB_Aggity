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

        internal void CreateTable(DataTable dataTable)
        {
            
        }

        private void CreateTableFromSchema(DataTable dt)
        {
            // Drop the new table if it is already there.

            StringBuilder sqlCmd = new StringBuilder(
            "if exists (SELECT * FROM dbo.sysobjects WHERE id = " +
            "object_id([" + DestinationTable + "]) " +
            "AND OBJECTPROPERTY(id, IsUserTable) = 1)" +
            Environment.NewLine +
            "DROP TABLE " + DestinationTable + ";" + Environment.NewLine +
            Environment.NewLine);

            // Start building a command string to create the table.
            sqlCmd.Append("CREATE TABLE [" + DestinationTable + "] (" +
            Environment.NewLine);
            // Iterate over the column collection in the source table.
            foreach (DataColumn col in dt.Columns)
            {
                // Add the column.
                sqlCmd.Append("[" + col.ColumnName + "] ");
                // Map the source column type to a SQL Server type.
                sqlCmd.Append(NetType2SqlType(col.DataType.ToString(),
                col.MaxLength) + " ");
                // Add identity information.
                if (col.AutoIncrement)
                    sqlCmd.Append("IDENTITY ");
                // Add AllowNull information.
                sqlCmd.Append((col.AllowDBNull ? "" : "NOT ") + "NULL," +
                Environment.NewLine);
            }
            sqlCmd.Remove(sqlCmd.Length - (Environment.NewLine.Length + 1), 1);
            sqlCmd.Append(") ON [PRIMARY];" + Environment.NewLine +
            Environment.NewLine);

            // Add the primary key to the table, if it exists.
            if (dt.PrimaryKey != null)
            {
                sqlCmd.Append("ALTER TABLE " + DestinationTable +
                " WITH NOCHECK ADD " + Environment.NewLine);
                sqlCmd.Append("CONSTRAINT [PK_" + DestinationTable +
                "] PRIMARY KEY CLUSTERED (" + Environment.NewLine);
                // Add the columns to the primary key.
                foreach (DataColumn col in dt.PrimaryKey)
                {
                    sqlCmd.Append("[" + col.ColumnName + "]," +
                    Environment.NewLine);
                }
                sqlCmd.Remove(sqlCmd.Length -
                (Environment.NewLine.Length + 1), 1);
                sqlCmd.Append(") ON [PRIMARY];" + Environment.NewLine +
                Environment.NewLine);
            }


            // Create and execute the command to create the new table.
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            SqlCommand cmd = new SqlCommand(sqlCmd.ToString(), conn);
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