using System;

namespace Basic_Payslip_Kata
{
    class Program //should this be renamed?
    {
 

        static void Main(string[] args)
        {
            //ask about this
            PayslipGenerator payslipGenerator = new PayslipGenerator();
            payslipGenerator.generate();
        }
    }
}