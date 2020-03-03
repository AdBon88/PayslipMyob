using System;
namespace Basic_Payslip_Kata
{
    public class Employee
    {
        private String firstName;
        private String surname;
        private int annualSalary;
        private int superRate;

        public Employee(String firstName, String surname, int annualSalary, int superRate)
        {
            this.firstName = firstName;
            this.surname = surname;
            this.annualSalary = annualSalary;
            this.superRate = superRate;
        }
    }
}
