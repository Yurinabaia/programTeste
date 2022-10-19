## Projeto de teste para empresa Audaztec

 Refatorado etapas do código e criado um teste unitario para avaliar a consistencia da crianção de um FARE.


### Validando se a tarifa foi criado no periodo de seis meses e o status foi 1 e operador é o mesmo.
~~~c# 

            var fare = GetFares();
            //Se for true significar que o operador possuir uma tarifa com mesmo valor no periodo de 6 meses
            return fare.Exists(x => x.OperatorId == operato.Id && x.Status == 1 && x.Value == value && x.DateCreated.AddMonths(6) <=  DateTime.Now);
~~~

### Teste unitario para avaliar o processo de criação da tarifa. 

~~~c#
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
  ~~~



