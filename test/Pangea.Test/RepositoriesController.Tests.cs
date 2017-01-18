using System;
using Xunit;
using PangeaProject.Controllers;

namespace PangeaProject.Test
{
    public class RepositoriesController_Tests
    {
        [Fact]
        public void Get_Blank_Value_Test() 
        {
            var controller = new RepositoriesController(null);

            var result = controller.Get();

            string expected = "LoadData request has been submitted.";
            Assert.True(result.ToString() == expected,"Load Data Controller Get method failed.");
        }
    }
}
