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
        public int MaxOfInstallments { get; set; }
        public ITaxServicePayment TaxServicePayment { get; private set; }

        public ContractService(int maxOfInstallments, ITaxServicePayment taxServicePayment)
        {
            MaxOfInstallments = maxOfInstallments;
            TaxServicePayment = taxServicePayment;
        }

        public void ProcessingContract(Contract contract)
        {

            for (int currentInstallment = 1; currentInstallment <= MaxOfInstallments; currentInstallment++)
            {
                DateTime dueDate = contract.Date.AddMonths(currentInstallment);

                double valueOfInstallment = contract.TotalValue / MaxOfInstallments;
                double amount = TaxServicePayment.TaxCalculations(currentInstallment, valueOfInstallment);

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
