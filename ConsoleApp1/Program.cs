using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Controllers;
using TestePleno.Models;

namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            var fare = new Fare();
            var fareController = new FareController();
            var @operator = new Operator();
            var operatorController = new OperatorController();
            fare.Id = Guid.NewGuid();
            @operator.Id = Guid.NewGuid();
            Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
            var fareValueInput = Console.ReadLine();
            fare.Value = decimal.Parse(fareValueInput == null ? "0.0" : fareValueInput);

            Console.WriteLine("Informe o código da operadora para a tarifa:");
            Console.WriteLine("Exemplos: OP01, OP02, OP03...");
            var operatorCodeInput = Console.ReadLine();

            @operator.Code = operatorCodeInput;
            operatorController.CreateOperator(@operator);
            
            bool createSucess = fareController.CreateFare(fare, @operator, operatorController.GetOperators());
            if (createSucess)
              Console.WriteLine("Tarifa cadastrada com sucesso!");
            else
              Console.WriteLine("Tarefina não pode ser cadastra pois não atende as requisiçoes: " +
                        "\n O mesmo operator com mesmo valor e com menos de seis meses");
            Console.Read();
        }
    }
}
