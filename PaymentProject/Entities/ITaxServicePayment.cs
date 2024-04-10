using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProject.Entities
{
    internal interface ITaxServicePayment
    {
        double TaxCalculations(int currentInstallment, double valueOfInstallment);
    }
}
