using CollegeManagementApi.Controllers;
using CollegeManagementApi.Models;
using CollegeManagementApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CollegeManagementTest
{
    [TestClass]
    class FileHandlingTest
    {
        [TestMethod]
        public async Task SaveFileTest()
        {
            //arrange
            string path = "C:/Users/shivcharan/Desktop/";
            string fileName = "test file.pdf";
            FileStream fs = new FileStream(path+fileName, FileMode.Open);
            
            //act

            //assert

        }
    }
}
