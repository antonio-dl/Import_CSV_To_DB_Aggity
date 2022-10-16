using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Data;

namespace Utilities.Tests
{
    [TestClass()]
    public class ImportManagerTests
    {
        ImportManager importManager = new("sales.order_items", @"Data Source=localhost;Initial Catalog=Bike;Integrated Security=True");

        [TestMethod()]
        public void ImportCSVToDatabaseTest()
        {
            importManager.ImportCSVToDatabase(@"C:\Users\antonio.deluca\Desktop\bike-sales-costumers.txt", ',');
            Console.WriteLine("Successo");

        }

        //[TestMethod()]
        //public void ParseToDataTableTest()
        //{
        //    System.Data.DataTable dt = importManager.ParseToDataTable(File.ReadAllLines(@"C:\Users\antonio.deluca\Desktop\bike-sales-costumers.txt"), ',');
        //    string JSONresult;
        //    JSONresult = JsonConvert.SerializeObject(dt,Formatting.Indented,new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

        //    Console.WriteLine(JSONresult);

        //    DataTable reverse = JsonConvert.DeserializeObject<DataTable>(JSONresult);

        //    Console.WriteLine(reverse);
        //}
    }
}