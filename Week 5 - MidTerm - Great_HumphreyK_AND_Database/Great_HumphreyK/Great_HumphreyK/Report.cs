using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Great_HumphreyK
{
    public class Report
    {
        private static SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;"
        + "AttachDbFilename=C:\\Database\\Great_HumphreyK_.mdf;"
        + "Integrated Security=True");



        public void OpenConnection()
        {
            try
            {
                // Open Connection
                sqlConnection.Open();
                Console.WriteLine("Connection Opened");
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        public void CloseConnection()
        {
            sqlConnection.Close();
            Console.WriteLine("Connection Closed");
            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();
        }

        public void EmployeeReport()
        {
            decimal PresidentBonus = 0;
            decimal SalesManagerBonus = 0;
            decimal ManagerBonusRate = 0;
            decimal Bonus = 0;
            decimal MonthlySalary = 0;
            decimal SalesAmt = 0;
            decimal CarAllowance = 0;
            decimal RunningSalesTotal = 0;
            decimal SalesGrandTotal = 0;
            decimal SalaryGrandTotal = 0;
            decimal CarAllowanceGrandTotal = 0;

            try
            {

                string sql = "SELECT * " +
                    "FROM Personnel " +
                    "FULL JOIN JobInformation ON (Personnel.ID = JobInformation.ID) " +
                    "FULL JOIN Expense ON (Personnel.ID = Expense.ID) " +
                    "ORDER BY JobInformation.JobTitle ASC, JobInformation.MonthlySalary";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-9} | {8,-10} | {9,-13}", "ID", "First Name", "Last Name", "DOB", "HireDate", "Job Title", "Monthly Salary", "Sales Amt", "Bonus Rate", "Car Allowance");
                Console.WriteLine("==========================================================================================================================================================================\n");

                while (dr.Read())
                {
                    if ((string)dr["JobTitle"] == "President" || (string)dr["JobTitle"] == "Sales Manager")
                    {
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        CarAllowance = (decimal)dr["CarAllowance"];

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        CarAllowanceGrandTotal = CarAllowanceGrandTotal + CarAllowance;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        dr["SalesAmt"],
                        dr["BonusRate"],
                        CarAllowance.ToString("C"));
                    }

                    if ((string)dr["JobTitle"] == "Sales Associate")
                    {
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        SalesAmt = (decimal) dr["SalesAmt"];
                        CarAllowance = (decimal)dr["CarAllowance"];

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        CarAllowanceGrandTotal = CarAllowanceGrandTotal + CarAllowance;
                        SalesGrandTotal = SalesGrandTotal + SalesAmt;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        SalesAmt.ToString("C"),
                        dr["BonusRate"],
                        CarAllowance.ToString("C"));
                    }
                    if ((string)dr["JobTitle"] == "Programmer" || (string)dr["JobTitle"] == "Programmer Associate")
                    {
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        dr["SalesAmt"],
                        dr["BonusRate"],
                        dr["CarAllowance"]);
                    }
                }

                Console.WriteLine("==========================================================================================================================================================================\n");
                Console.WriteLine("{0,-112} {1,-18} {2, -27} {3,-13}", "Grand Totals:", SalaryGrandTotal.ToString("C"), SalesGrandTotal.ToString("C"), CarAllowanceGrandTotal.ToString("C"));

                dr.Close();
            }

            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " +
                ex.ToString());
            }

        }

        public void CalculateBonusAmt()
        {
            //Make a new report column that contains the calculated bonus amount. You may use abbreviations in your column header
            decimal PresidentBonus = 0;
            decimal SalesManagerBonus = 0;
            decimal RunningSalesTotal = 0;
            decimal ManagerBonusRate = 0;
            decimal Bonus = 0;
            decimal MonthlySalary = 0;
            decimal SalesAmt = 0;
            decimal CarAllowance = 0;
            decimal SalesGrandTotal = 0;
            decimal SalaryGrandTotal = 0;
            decimal CarAllowanceGrandTotal = 0;
            decimal BonusGrandTotal = 0;

            try
            {
                //
                //
                //
                //
                //Find president's bonus amount and save to a variable called PresidentBonus

                string sql = "SELECT * " +
                    "FROM Personnel " +
                    "FULL JOIN JobInformation ON (Personnel.ID = JobInformation.ID) " +
                    "FULL JOIN Expense ON (Personnel.ID = Expense.ID) " +
                    "ORDER BY JobInformation.JobTitle ASC, JobInformation.MonthlySalary";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if ((string)dr["JobTitle"] == "President")
                    {
                        PresidentBonus = (decimal)dr["BonusRate"] * (decimal)dr["MonthlySalary"] / 100;
                    }
                }
                dr.Close();
                //
                //
                //
                //
                //Find Sales Manager's bonus amount and save to a variable called PresidentBonus
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if ((string)dr["JobTitle"] == "Sales Associate")
                    {
                        RunningSalesTotal = RunningSalesTotal + (decimal)dr["SalesAmt"];
                    }

                    if ((string)dr["JobTitle"] == "Sales Manager")
                    {
                        ManagerBonusRate = (decimal)dr["BonusRate"];
                    }
                }
                SalesManagerBonus = ManagerBonusRate * RunningSalesTotal / 100;
                dr.Close();
                //
                //
                //
                //
                //Find remaining datapoints and print 
                dr = cmd.ExecuteReader();


                Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10}", "ID", "First Name", "Last Name", "DOB", "HireDate", "Job Title", "Monthly Salary", "Sales Amt", "Bonus Rate", "Car Allowance", "Bonus");
                Console.WriteLine("==========================================================================================================================================================================================\n");

                while (dr.Read())
                {

                    if ((string)dr["JobTitle"] == "President")
                    {
                        Bonus = PresidentBonus;
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        CarAllowance = (decimal)dr["CarAllowance"];

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        CarAllowanceGrandTotal = CarAllowanceGrandTotal + CarAllowance;
                        BonusGrandTotal = BonusGrandTotal + Bonus;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        dr["SalesAmt"],
                        dr["BonusRate"],
                        CarAllowance.ToString("C"),
                        Bonus.ToString("C"));
                    }

                    if ((string)dr["JobTitle"] == "Sales Manager")
                    {
                        Bonus = SalesManagerBonus;
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        CarAllowance = (decimal)dr["CarAllowance"];

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        CarAllowanceGrandTotal = CarAllowanceGrandTotal + CarAllowance;
                        BonusGrandTotal = BonusGrandTotal + Bonus;


                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        dr["SalesAmt"],
                        dr["BonusRate"],
                        CarAllowance.ToString("C"),
                        Bonus.ToString("C"));
                    }

                    if ((string)dr["JobTitle"] == "Sales Associate")
                    {
                        Bonus = (decimal)dr["BonusRate"] * (decimal)dr["SalesAmt"] / 100;
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        SalesAmt = (decimal)dr["SalesAmt"];
                        CarAllowance = (decimal)dr["CarAllowance"];

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        CarAllowanceGrandTotal = CarAllowanceGrandTotal + CarAllowance;
                        SalesGrandTotal = SalesGrandTotal + SalesAmt;
                        BonusGrandTotal = BonusGrandTotal + Bonus;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        SalesAmt.ToString("C"),
                        dr["BonusRate"],
                        CarAllowance.ToString("C"),
                        Bonus.ToString("C"));
                    }

                    if ((string)dr["JobTitle"] == "Programmer" || (string)dr["JobTitle"] == "Programmer Associate")
                    {
                        Bonus = 0;
                        MonthlySalary = (decimal)dr["MonthlySalary"];

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        dr["SalesAmt"],
                        dr["BonusRate"],
                        dr["CarAllowance"],
                        Bonus.ToString("C"));
                    }
                }

                Console.WriteLine("==========================================================================================================================================================================================\n");
                Console.WriteLine("{0,-112} {1,-18} {2, -27} {3,-15} {4,-10}", "Grand Totals:", SalaryGrandTotal.ToString("C"), SalesGrandTotal.ToString("C"), CarAllowanceGrandTotal.ToString("C"), BonusGrandTotal.ToString("C"));

                dr.Close();
            }

            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " +
                ex.ToString());
            }


        }

        public void TotalCompensation()
        {
            //Make a new report column that contains the total compensation (salary + bonus amount + car allowance). You may use abbreviations in your column
            //header.

            decimal PresidentBonus = 0;
            decimal SalesManagerBonus = 0;
            decimal RunningSalesTotal = 0;
            decimal ManagerBonusRate = 0;
            decimal Bonus = 0;
            decimal MonthlySalary = 0;
            decimal SalesAmt = 0;
            decimal CarAllowance = 0;
            decimal TotalCompensation = 0;
            decimal SalesGrandTotal = 0;
            decimal SalaryGrandTotal = 0;
            decimal CarAllowanceGrandTotal = 0;
            decimal BonusGrandTotal = 0;
            decimal TotalCompGrandTotal = 0;

            try
            {
                //
                //
                //
                //
                //Find president's bonus amount and save to a variable called PresidentBonus

                string sql = "SELECT * " +
                    "FROM Personnel " +
                    "FULL JOIN JobInformation ON (Personnel.ID = JobInformation.ID) " +
                    "FULL JOIN Expense ON (Personnel.ID = Expense.ID) " +
                    "ORDER BY JobInformation.JobTitle ASC, JobInformation.MonthlySalary";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if ((string)dr["JobTitle"] == "President")
                    {
                        PresidentBonus = (decimal)dr["BonusRate"] * (decimal)dr["MonthlySalary"] / 100;
                    }
                }
                dr.Close();
                //
                //
                //
                //
                //Find Sales Manager's bonus amount and save to a variable called PresidentBonus
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if ((string)dr["JobTitle"] == "Sales Associate")
                    {
                        RunningSalesTotal = RunningSalesTotal + (decimal)dr["SalesAmt"];
                    }

                    if ((string)dr["JobTitle"] == "Sales Manager")
                    {
                        ManagerBonusRate = (decimal)dr["BonusRate"];
                    }
                }
                SalesManagerBonus = ManagerBonusRate * RunningSalesTotal / 100;
                dr.Close();
                //
                //
                //
                //
                //Find remaining datapoints and print 
                dr = cmd.ExecuteReader();


                Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10} | {11,-15}", "ID", "First Name", "Last Name", "DOB", "HireDate", "Job Title", "Monthly Salary", "Sales Amt", "Bonus Rate", "Car Allowance", "Bonus", "Total Comp");
                Console.WriteLine("======================================================================================================================================================================================================\n");

                while (dr.Read())
                {

                    if ((string)dr["JobTitle"] == "President")
                    {
                        Bonus = PresidentBonus;
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        CarAllowance = (decimal)dr["CarAllowance"];
                        TotalCompensation = MonthlySalary + Bonus + CarAllowance;

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        CarAllowanceGrandTotal = CarAllowanceGrandTotal + CarAllowance;
                        BonusGrandTotal = BonusGrandTotal + Bonus;
                        TotalCompGrandTotal = TotalCompGrandTotal + TotalCompensation;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10} | {11,-15}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        dr["SalesAmt"],
                        dr["BonusRate"],
                        CarAllowance.ToString("C"),
                        Bonus.ToString("C"),
                        TotalCompensation.ToString("C"));
                    }

                    if ((string)dr["JobTitle"] == "Sales Manager")
                    {
                        Bonus = SalesManagerBonus;
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        CarAllowance = (decimal)dr["CarAllowance"];
                        TotalCompensation = MonthlySalary + Bonus + CarAllowance;

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        CarAllowanceGrandTotal = CarAllowanceGrandTotal + CarAllowance;
                        BonusGrandTotal = BonusGrandTotal + Bonus;
                        TotalCompGrandTotal = TotalCompGrandTotal + TotalCompensation;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10} | {11,-15}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        dr["SalesAmt"],
                        dr["BonusRate"],
                        CarAllowance.ToString("C"),
                        Bonus.ToString("C"),
                        TotalCompensation.ToString("C"));
                    }

                    if ((string)dr["JobTitle"] == "Sales Associate")
                    {
                        Bonus = (decimal)dr["BonusRate"] * (decimal)dr["SalesAmt"] / 100;
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        SalesAmt = (decimal)dr["SalesAmt"];
                        CarAllowance = (decimal)dr["CarAllowance"];
                        TotalCompensation = MonthlySalary + Bonus + CarAllowance;

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        CarAllowanceGrandTotal = CarAllowanceGrandTotal + CarAllowance;
                        SalesGrandTotal = SalesGrandTotal + SalesAmt;
                        BonusGrandTotal = BonusGrandTotal + Bonus;
                        TotalCompGrandTotal = TotalCompGrandTotal + TotalCompensation;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10} | {11,-15}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        SalesAmt.ToString("C"),
                        dr["BonusRate"],
                        CarAllowance.ToString("C"),
                        Bonus.ToString("C"),
                        TotalCompensation.ToString("C"));
                    }

                    if ((string)dr["JobTitle"] == "Programmer" || (string)dr["JobTitle"] == "Programmer Associate")
                    {
                        Bonus = 0;
                        MonthlySalary = (decimal)dr["MonthlySalary"];
                        TotalCompensation = MonthlySalary;

                        SalaryGrandTotal = SalaryGrandTotal + MonthlySalary;
                        TotalCompGrandTotal = TotalCompGrandTotal + TotalCompensation;

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25} | {5,-20} | {6,-16} | {7,-12} | {8,-10} | {9,-13} | {10,-10} | {11,-15}",
                        dr["ID"],
                        dr["FirstName"],
                        dr["LastName"],
                        dr["DOB"],
                        dr["HireDate"],
                        dr["JobTitle"],
                        MonthlySalary.ToString("C"),
                        dr["SalesAmt"],
                        dr["BonusRate"],
                        dr["CarAllowance"],
                        Bonus.ToString("C"),
                        TotalCompensation.ToString("C"));
                    }
                }

                Console.WriteLine("======================================================================================================================================================================================================\n");
                Console.WriteLine("{0,-112} {1,-18} {2, -27} {3,-15} {4,-12} {5,-15}", "Grand Totals:", SalaryGrandTotal.ToString("C"), SalesGrandTotal.ToString("C"), CarAllowanceGrandTotal.ToString("C"), BonusGrandTotal.ToString("C"), TotalCompGrandTotal.ToString("C"));
                dr.Close();
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " +
                ex.ToString());
            }
        }




        /*1.Print out at the bottom of your report the appropriate grand totals(monthly salary, sales amount, total monthly compensation, car allowance, etc.).
2.Sort the data by Job Title, Monthly salary(ascending for each field).
3.Sort the data by Job Title, Total Compensation(ascending for each field).*/
    }
}
