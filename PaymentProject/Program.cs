
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using PaymentProject.Entities;
using PaymentProject.Services;

namespace PaymentProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");

            Console.Write("Number: ");
            int numberOfContract = Convert.ToInt32(Console.ReadLine());

            Console.Write("Date (dd/MM/yyyy): ");
            DateTime inicialDateOfContract = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Contract value: ");
            double contractValue = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter number of installments: ");
            int numberOfInstallments = Convert.ToInt32(Console.ReadLine());

            Contract contract = new Contract(numberOfContract, inicialDateOfContract, contractValue);
            

            ContractService contractService = new ContractService(numberOfInstallments, new PaypalTaxService());
            contractService.ProcessingContract(contract);


        }
    }
}
