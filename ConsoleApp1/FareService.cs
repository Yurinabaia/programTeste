using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class FareService
    {
        private Repository _repository = new Repository();

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }

        public bool ValidatedFareWithOperator(Operator operato, decimal value) 
        {
            var fare = GetFares();
            //Se for true significar que o operador possuir uma tarifa com mesmo valor no periodo de 6 meses
            return fare.Exists(x => x.OperatorId == operato.Id && x.Value == value && x.DateCreated.AddMonths(6) <=  DateTime.Now);
        }
    }
}
