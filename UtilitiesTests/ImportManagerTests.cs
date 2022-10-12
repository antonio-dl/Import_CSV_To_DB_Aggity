using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Tests
{
    [TestClass()]
    public class ImportManagerTests
    {
        ImportManager importManager = new( "production.brands", @"Data Source=localhost;Initial Catalog=Bike;Integrated Security=True");

        [TestMethod()]
        public void ImportCSVToDatabaseTest()
        {
            importManager.ImportCSVToDatabase(@"C:\Users\antonio.deluca\Desktop\bike-production-brands.txt", ',');


        }
    }
}