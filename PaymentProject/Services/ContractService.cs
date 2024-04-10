using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentProject.Entities;
namespace PaymentProject.Services
{
    internal class ContractService
    {
        public int NumbersOfInstallments { get; set; }

        public ContractService(int numbersOfInstallments)
        {
            NumbersOfInstallments = numbersOfInstallments;
        }

        public void ProcessingContract(Contract contract)
        {

            for (int i = 1; i <= NumbersOfInstallments; i++)
            {
                DateTime dueDate = contract.Date.AddMonths(i);
                
                PaypalTaxService pay = new PaypalTaxService();
                double valueOfInstallment = contract.TotalValue / NumbersOfInstallments;
                double amount = pay.TaxCalculations(i, valueOfInstallment);

                Installment installment = new Installment(dueDate, amount);
                contract.Installments.Add(installment);

            }

            Console.WriteLine("Installments:");
            foreach (var instalment in contract.Installments)
            {
                Console.WriteLine($"{instalment.DueDate:d} - {instalment.Amount:C}");
            }

        }

       

    }
}
