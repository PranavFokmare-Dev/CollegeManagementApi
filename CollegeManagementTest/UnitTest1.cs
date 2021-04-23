using CollegeManagementApi.Controllers;
using CollegeManagementApi.Models;
using CollegeManagementApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            //arrange
            var mockStudentRepo = new Mock<IStudentRepository>();
            mockStudentRepo.Setup(r => r.GetStudents()).Returns(Task.FromResult<IEnumerable<Student>>(new List<Student>()));
            var controller = new StudentsController(mockStudentRepo.Object);

            //act
            var result = await controller.GetStudents();

            //assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Student>));
        }

        [TestMethod]
        public async Task Test()
        {            //arrange
            var mockStudentRepo = new Mock<IStudentRepository>();
            mockStudentRepo.Setup(r => r.GetStudents()).Returns(Task.FromResult<IEnumerable<Student>>(new List<Student>()));
            var controller = new StudentsController(mockStudentRepo.Object);

            //act
            var result = await controller.GetStudents();

            //assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Student>));
        }

    }
}
