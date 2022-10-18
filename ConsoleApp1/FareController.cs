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
        public FareService FareService;

        public FareController()
        {
            _operatorService = new OperatorService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            FareService = new FareService();
            if (selectedOperator != null)
            {
                fare.OperatorId = selectedOperator.Id;
                //Caso o operador possuir uma tarifa igual no periodo de 6 meses do mesmo valor não vai salvar 
                if (FareService.ValidatedFareWithOperator(selectedOperator, fare.Value))
                    return;
            }
            FareService.Create(fare);
        }
    }
}
