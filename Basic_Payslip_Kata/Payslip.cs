using System;

//TODO ask if the calculation methods should be in this classs
namespace Basic_Payslip_Kata {
    public class Payslip {
        private Employee employee;
        private DateTime startDate;
        private DateTime endDate;
        int grossIncome;
        int incomeTax;
        int netIncome;
        int super;

        public Payslip(Employee employee, DateTime startDate, DateTime endDate) {
            this.employee = employee;
            this.startDate = startDate;
            this.endDate = endDate;
            this.grossIncome = calculateGrossIncome();
            this.incomeTax = calculateIncomeTax();
            this.netIncome = calculateNetIncome();
            this.super = calculateSuper();
        }

        private int calculateGrossIncome() {
            int annualSalary = employee.getAnnualSalary();
            int monthsInPeriod;
            double unroundedGrossIncome;
            int roundedGrossIncome;
            Console.WriteLine(annualSalary);

            //gives whole months between two dates, day of months is irrelevant
            monthsInPeriod = ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month + 1;
            unroundedGrossIncome = (double)annualSalary / 2 * monthsInPeriod; //is it correct to cast like this?
            roundedGrossIncome = (int)Math.Round(unroundedGrossIncome, 0, MidpointRounding.AwayFromZero);

            return roundedGrossIncome;
        }

        //TODO ask about appropriateness of numerical types (double vs decimal etc)
        private int calculateIncomeTax() {
            int annualSalary = employee.getAnnualSalary();
            double unroundedIncomeTax;
            int roundedIncomeTax;

            //TODOI suspect there is a better way to do this than using a case statement...
            switch (annualSalary) {
                case int n when (n <= 18200):
                    unroundedIncomeTax = 0.00;
                    break;
                case int n when (n > 18200 && n <= 37000):
                    unroundedIncomeTax = (annualSalary - 18200) * 0.19;
                    break;
                case int n when (n > 37000 && n <= 87000):
                    unroundedIncomeTax = (annualSalary - 37000) * 0.325 + 3572;
                    break;
                case int n when (n > 87000 && n <= 180000):
                    unroundedIncomeTax = (annualSalary - 87000) * 0.37 + 19822;
                    break;
                case int n when (n > 180000):
                    unroundedIncomeTax = (annualSalary - 180000) * 0.45 + 54232;
                    break;
                default:
                    unroundedIncomeTax = 0.00;
                    break;
            }
            roundedIncomeTax = (int)Math.Round(unroundedIncomeTax, 0, MidpointRounding.AwayFromZero);

            return roundedIncomeTax;
        }

        private int calculateNetIncome() {
            return grossIncome - incomeTax;
        }

        private int calculateSuper() {
            int superRate = employee.getSuperRate();
            double unroundedSuper;
            int roundedSuper;

            unroundedSuper = (double)grossIncome * (superRate / 100.00);
            roundedSuper = (int)Math.Round(unroundedSuper, 0, MidpointRounding.AwayFromZero);

            return roundedSuper;
        }

        public string toString() {
            string stringPayslip;

            string firstName = employee.getFirstName();
            string surname = employee.getSurname();

            stringPayslip = "Name: " + firstName + " " + surname + "/n"
                + "Pay period: " + 
       

        }
    }
}

