using System;

namespace Basic_Payslip_Kata {
    public class Payslip {

        //apparently in C# it's convention to put a _ before private fields? News to me!
        private Employee employee;
        private DateTime startDate;
        private DateTime endDate;
        private decimal grossIncome;
        private decimal incomeTax;
        private decimal netIncome;
        private decimal super;

        public Payslip(Employee employee, DateTime startDate, DateTime endDate) {
            this.employee = employee;
            this.startDate = startDate;
            this.endDate = endDate;
            grossIncome = calculateGrossIncome();
            incomeTax = calculateIncomeTax();
            netIncome = calculateNetIncome();
            super = calculateSuper();
        }

        private decimal calculateGrossIncome() {
            decimal annualSalary = employee.getAnnualSalary();
            decimal monthsInPeriod;
            decimal grossIncome;

            //gives whole months between two dates, day of months is irrelevant
            monthsInPeriod = ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month + 1;
            grossIncome = annualSalary/12 * monthsInPeriod;
            grossIncome = Math.Round(grossIncome, 0, MidpointRounding.AwayFromZero);
            return grossIncome;
        }

        private decimal calculateIncomeTax() {
            decimal annualSalary = employee.getAnnualSalary();
            decimal incomeTax;

            //TODO I suspect there is a better way to do this than using a switch...
            switch (annualSalary) {
                case decimal n when (n <= 18200):
                    incomeTax = 0;
                    break;
                case decimal n when (n > 18200 && n <= 37000):
                    incomeTax = (annualSalary - 18200) * 0.19m/12;
                    break;
                case decimal n when (n > 37000 && n <= 87000):
                    incomeTax = ((annualSalary - 37000) * 0.325m + 3572)/12;
                    break;
                case decimal n when (n > 87000 && n <= 180000):
                    incomeTax = ((annualSalary - 87000) * 0.37m + 19822)/12; 
                    break;
                case decimal n when (n > 180000):
                    incomeTax = ((annualSalary - 180000) * 0.45m + 54232)/12;
                    break;
                default:
                    incomeTax = 0;
                    break;
            }
            incomeTax = Math.Round(incomeTax, 0, MidpointRounding.AwayFromZero);

            return incomeTax;
        }

        private decimal calculateNetIncome() {
            return grossIncome - incomeTax;
        }

        private decimal calculateSuper() {
            decimal superRate = employee.getSuperRate();
            decimal super;

            super = grossIncome * (superRate / 100);
            super = Math.Round(super, 0, MidpointRounding.AwayFromZero);

            return super;
        }

        public string toString() {
            string stringPayslip;
            string firstName = employee.getFirstName();
            string surname = employee.getSurname();

            stringPayslip = "Name: " + firstName + " " + surname + "\n"
                + "Pay period: " + startDate.ToString("dd MMMM") + " - " + endDate.ToString("dd MMMM") + "\n"
                + "Gross Income: " + grossIncome + "\n"
                + "Income Tax: " + incomeTax + "\n"
                + "Net Income: " + netIncome + "\n"
                + "Super: " + super;

            return stringPayslip;

        }
    }
}

