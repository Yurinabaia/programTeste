using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.Models
{
    public class Fare : IModel
    {
        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        public DateTime DateCreated { get; private set; } = DateTime.Now;
        public int Status { get; set; } = 1;
        public decimal Value { get; set; }
    }
}
