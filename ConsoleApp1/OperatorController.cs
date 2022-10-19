using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class OperatorController
    {
        private OperatorService _operatorService;
        public FareService FareService;

        public OperatorController()
        {
            FareService = new FareService();
            _operatorService = new OperatorService();
        }

        public void CreateOperator(Operator @operator)
        {
            _operatorService.Create(@operator);
        }
        public List<Operator> GetOperators() 
        {
           return _operatorService.GetOperators();
        }
    }
}
