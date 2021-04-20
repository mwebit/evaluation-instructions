using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using middlewareTest.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Configuration;
using middlewareTest.Services;

namespace Middleware.Tests
{
    public class CompaniesControllerTest
    {
      
        [Fact]
        public async Task verify_company_name()
        {
            //Arrange
            
            var b2b  = new B2bData();

            //Act
            var retResult = await b2b.GetData("https://raw.githubusercontent.com/MiddlewareNewZealand/evaluation-instructions/main/xml-api/1.xml");

            //Assert
            
            Assert.Contains("MWNZ",retResult);
        }
    }
}
