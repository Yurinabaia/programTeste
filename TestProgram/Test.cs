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
            Operator @operator = new Operator();
            fare.Id = Guid.NewGuid();
            @operator.Id = Guid.NewGuid();
            fare.Value = decimal.Parse("4.5");
            @operator.Code = "OP01";
            var fareController = new FareController();
            var operatorController = new OperatorController();

            operatorController.CreateOperator(@operator);
            bool fireCreate = fareController.CreateFare(fare, @operator,operatorController.GetOperators());

            //Avaliar se é o mesmo ID
            Assert.True(fireCreate);
        }
    }
}
