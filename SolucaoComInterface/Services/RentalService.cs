using System;
using SolucaoComInterface.Entities;
using SolucaoComInterface.Services;

namespace SolucaoComInterface.Services
{
    class RentalService //Nessa solução com interface a classe RentalService terá uma dependencia com uma interface genérica (ITaxService) sendo um serviço de imposto geral aonde será definido um contrato que o serviço de imposto deve cumprir que é a operação Tax. E apartir disso podemos criar serviços específicos que implementem essa interface.
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxService TaxService; //Agora na solução com interface ao invés de declarar e intânciar um serviço BrazilTaxService é necessário declarar apenas a interface do serviço que é a ITaxService, ou seja nessa declaração esta esperando um serviço de imposto qualquer.
        public RentalService(double pricePerHour, double pricePerDay, ITaxService iTaxService) //Acrescenta um parâmetro do tipo ITaxService no construtor para que ele também receba esse objeto, e isso é chamado de inverção de controle por meio de injeção de dependência.
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            TaxService = iTaxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;

            if(duration.TotalHours <= 12.0)
            {
                basicPayment += PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax= TaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }

    }
}
