using System;

namespace Basic_Payslip_Kata
{
    class Program //should this be renamed?
    {
 

        static void Main(string[] args)
        {
            //Is it necessary to separate the entry point into its own class?
            PayslipGenerator payslipGenerator = new PayslipGenerator();
            payslipGenerator.run();
        }
    }
}