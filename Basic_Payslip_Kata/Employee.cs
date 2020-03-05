using System;
namespace Basic_Payslip_Kata {
    public class Employee {
        private string firstName;
        private string surname;
        private decimal annualSalary;
        private decimal superRate;

        public Employee(string firstName, string surname, int annualSalary, int superRate) {
            this.firstName = firstName;
            this.surname = surname;
            this.annualSalary = annualSalary;
            this.superRate = superRate;
        }

        public decimal getAnnualSalary() {
            return annualSalary;
        }

        public decimal getSuperRate() {
            return superRate;
        }

        public string getFirstName() {
            return firstName;
        }

        public string getSurname() {
            return surname;
        }
    }
}
