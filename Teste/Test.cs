using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestePleno.Controllers;
using TestePleno.Models;
using Xunit;

namespace TestePleno
{

    public class Test
    {
        [Fact(DisplayName = "TesteProgram")]
        public void TestarProgram()
        {
            Fare fare = new Fare();
            fare.Id = Guid.NewGuid();
            fare.Value = decimal.Parse("4.5");
            var operatorCodeInput = "OP01";
            var fareController = new FareController();
            fareController.CreateFare(fare, operatorCodeInput);


            Assert.NotNull(fareController.FareService);
        }
    }
}
