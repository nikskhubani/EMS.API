using System;
using System.Threading.Tasks;
using EMS.API.Controllers;
using EMS.API.Models;
using EMS.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace EMS.API.Tests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEMSRepository> _emsRepositoryMock;
        private EmployeeController _employeeController;

        [SetUp]
        public void Setup()
        {
            _emsRepositoryMock = new Mock<IEMSRepository>();
            _employeeController = new EmployeeController(_emsRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllAsync_ReturnsOkResult()
        {
            _emsRepositoryMock.Setup(repo => repo.GetEmployeesAsync()).ReturnsAsync(new APIResult());

            var result = await _employeeController.GetAllAsync();

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllResult()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee { Id = employeeId, FirstName = "John", LastName = "Doe" };
            var employeesList = new List<Employee> { employee };

            _emsRepositoryMock.Setup(repo => repo.GetEmployeesAsync()).ReturnsAsync(new APIResult { Employees = employeesList });

            // Act
            var result = await _employeeController.GetAllAsync();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var apiResult = okResult.Value as APIResult;
            Assert.IsNotNull(apiResult);

            var returnedEmployees = apiResult.Employees;
            Assert.IsNotNull(returnedEmployees);
            Assert.AreEqual(1, returnedEmployees.Count);

            var returnedEmployee = returnedEmployees[0];
            Assert.AreEqual(employeeId, returnedEmployee.Id);
            Assert.AreEqual("John", returnedEmployee.FirstName);
            Assert.AreEqual("Doe", returnedEmployee.LastName);
        }

        [Test]
        public async Task GetAsync_ReturnsEmployee()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee { Id = employeeId, FirstName = "John", LastName = "Doe" };

            _emsRepositoryMock.Setup(repo => repo.GetEmployeeAsync(employeeId)).ReturnsAsync(new APIResult(employee, null, APIResultType.OK, null));

            // Act
            var result = await _employeeController.GetAsync(employeeId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var apiResult = okResult.Value as APIResult;
            Assert.IsNotNull(apiResult);

            var returnedEmployee = apiResult.Employee;
            Assert.IsNotNull(returnedEmployee);
            Assert.AreEqual(employeeId, returnedEmployee.Id);
            Assert.AreEqual("John", returnedEmployee.FirstName);
            Assert.AreEqual("Doe", returnedEmployee.LastName);
        }

        [Test]
        public async Task UpdateAsync_ReturnsOkResult()
        {
            // Arrange
            var employeeId = 1;
            var updatedEmployee = new Employee { Id = employeeId, FirstName = "UpdatedFirstName", LastName = "UpdatedLastName" };

            _emsRepositoryMock.Setup(repo => repo.UpdateEmployeeAsync(updatedEmployee)).ReturnsAsync(new APIResult());

            // Act
            var result = await _employeeController.UpdateAsync(updatedEmployee);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task DeleteAsync_ReturnsOkResult()
        {
            // Arrange
            var employeeId = 1;

            _emsRepositoryMock.Setup(repo => repo.DeleteEmployeeAsync(employeeId)).ReturnsAsync(new APIResult());

            // Act
            var result = await _employeeController.DeleteAsync(employeeId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task Search_ReturnsOkResult()
        {
            string searchTerm = "John";
            _emsRepositoryMock.Setup(repo => repo.SearchEmployeeAsync(searchTerm)).Returns(new APIResult(null, null, APIResultType.OK, null));

            var result = _employeeController.Search(searchTerm);
            var okResult = result.Result as OkObjectResult;
            var apiResult = okResult.Value as APIResult;
            Assert.AreEqual("OK", apiResult.Status);
        }

        // Example of a test with an exception
        [Test]
        public void Search_ThrowsException_ReturnsBadRequest()
        {
            string searchTerm = "John";
            _emsRepositoryMock.Setup(repo => repo.SearchEmployeeAsync(searchTerm)).Throws(new Exception("Some error"));
            var result = _employeeController.Search(searchTerm);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
    }
}
