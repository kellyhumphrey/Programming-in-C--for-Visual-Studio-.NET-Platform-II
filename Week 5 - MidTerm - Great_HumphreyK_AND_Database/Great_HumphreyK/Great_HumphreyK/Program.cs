using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Great_HumphreyK
{
    public class Program
    {
        //Filepath for datebase in this project (found at the top of the "Report" class ) is: "C:\\Database\\Great_HumphreyK_.mdf"


        static void Main(string[] args)
        {
            Report print = new Report();
            print.OpenConnection();
            
            
            print.EmployeeReport();
            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();
                
            print.CalculateBonusAmt();
            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();

            print.TotalCompensation();
            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();


            print.CloseConnection();
            





            

        }
    }
}

