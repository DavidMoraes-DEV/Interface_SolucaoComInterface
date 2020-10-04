using SolucaoComInterface.Entities;
using SolucaoComInterface.Services;
using System;
using System.Globalization;

namespace SolucaoComInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //SOLUÇÃO COM INTERFACE: Ver a interface ITaxService e a classe específica da interface BrazilTaxService
            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:MM): ");
            DateTime pickup = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Rentur (dd/MM/yyyy hh:MM): ");
            DateTime _return = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(pickup, _return, new Vehicle(model));

            RentalService rentalService = new RentalService(pricePerHour, pricePerDay, new BrazilTaxService()); //Agora é necessário declarar um Serviço do tipo RentalService e Incluir um terceiro parâmetro com o tipo de dependência que será utilizado sendo que nesse caso é a classe comcreta BrazilTaxService() que casará com o terceiro parâmetro do construtor da classe RentalService por meio de UpCasting.

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE:");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
