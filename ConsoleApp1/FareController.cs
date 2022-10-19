using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService FareService;

        public FareController()
        {
            FareService = new FareService();
            _operatorService = new OperatorService();
        }

        public bool CreateFare(Fare fare,Operator @operator, List<Operator> operators)
        {
          var selectedOperator = _operatorService.GetOperatorByCode(@operator.Code, operators);
          fare.OperatorId = @operator.Id;
            //Caso o operador possuir uma tarifa igual no periodo de 6 meses do mesmo valor não vai salvar 
          if (selectedOperator != null && FareService.ValidatedFareWithOperator(selectedOperator, fare.Value))
              return false;
          FareService.Create(fare);
           return true;
        }
    }
}
