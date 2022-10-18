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
        [Fact(DisplayName = "TesteCriacaoFire")]
        public void TestarProgram()
        {
            Fare fare = new Fare();
            fare.Id = Guid.NewGuid();
            fare.Value = decimal.Parse("4.5");
            var operatorCodeInput = "OP01";
            var fareController = new FareController();
            fareController.CreateFare(fare, operatorCodeInput);

            //Avaliar se é o mesmo ID
            Assert.Equal(fare.Id,fareController.FareService.GetFareById(fare.Id).Id);
        }
    }
}
