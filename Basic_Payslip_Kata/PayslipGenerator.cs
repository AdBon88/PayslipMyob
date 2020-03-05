using System;
namespace Basic_Payslip_Kata {
    public class PayslipGenerator {
        private Employee employee;
        private Payslip payslip;

        public PayslipGenerator() {
        }

        public void start(){
            employee = getEmployeeDetailsFromUser();
            payslip = generatePayslip();
            Console.WriteLine("Your payslip has been generated:\n");
            Console.WriteLine(payslip.toString());
            Console.WriteLine("\nThank you for using MYOB!");   
        }

        private Employee getEmployeeDetailsFromUser() {
            string firstName;
            string surname;
            decimal annualSalary;
            decimal superRate;

            Console.WriteLine("Welcome to the payslip generator!");
            Console.WriteLine("");

            Console.WriteLine("Please enter your name:");
            firstName = Console.ReadLine();

            Console.WriteLine("Please enter your surname:");
            surname = Console.ReadLine();


            Console.WriteLine("Please enter your annual salary:");
            while (!decimal.TryParse(Console.ReadLine(), out annualSalary)) {
                Console.WriteLine("Please Enter a valid numerical value!");
            }
        
            Console.WriteLine("Please enter your super rate:");
            while (!decimal.TryParse(Console.ReadLine(), out superRate)){
                Console.WriteLine("Please Enter a valid numerical value!");
            }

            return new Employee(firstName, surname, annualSalary, superRate);
        }

        private Payslip generatePayslip() {

            Payslip payslip = getPayslipDatesFromUser(employee);

            return payslip;

        }
        private Payslip getPayslipDatesFromUser(Employee employee) {
            DateTime startDate;
            DateTime endDate;

            Console.WriteLine("Please enter your payment start date:");
            while (!DateTime.TryParse(Console.ReadLine(), out startDate)) {
                Console.WriteLine("Please enter a valid date! Eg. 6 March or 03/06/2020");
            }

            Console.WriteLine("Please enter your payment end date:");
            while (!DateTime.TryParse(Console.ReadLine(), out endDate)) {
                Console.WriteLine("Please enter a valid date! Eg. 6 March or 03/06/2020");
            }

            return new Payslip(employee, startDate, endDate);
        }
    }
}
