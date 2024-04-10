using PaymentProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProject.Services
{
    internal class PaypalTaxService : ITaxServicePayment
    {
        public double TaxCalculations(int currentInstallment, double valueOfInstallment)
        {
            double monthlySimpleInterest = valueOfInstallment + (valueOfInstallment * 0.01) * currentInstallment;
            double paymentFee = monthlySimpleInterest + (monthlySimpleInterest * 0.02);
            
            return paymentFee;
        }
    }
}
