using System;

public class Class1
{
	public Class1()
	{

		public void EmployeeReport()
		{
            //1.Print to the screen a data dump of all fields contained in your Employees table.
            //2.Output should be nicely formatted including column headers, aligned currency and numeric data, etc.

        }

		public void CalculateBonusAmt()
		{
            //Make a new report column that contains the calculated bonus amount. You may use abbreviations in your column header
        }

        public void TotalCompensation()
        {
            //Make a new report column that contains the total compensation (salary + bonus amount + car allowance). You may use abbreviations in your column
            //header.
        }

        
        
        
        /*1.Print out at the bottom of your report the appropriate grand totals(monthly salary, sales amount, total monthly compensation, car allowance, etc.).
2.Sort the data by Job Title, Monthly salary(ascending for each field).
3.Sort the data by Job Title, Total Compensation(ascending for each field).*/
    }
}




/*
Creating your database in pure code. For those of you who have the time and have some knowledge of Sql creating the EIS database in code is fairly easy. For
example, see the following URL:
https://support.microsoft.com/en-us/help/307283/how-to-create-a-sql-server-database-programmatically-by-using-ado-net
Bonus Points: 10.
2. Use an app.config file with a |DataDirectory| option. Note that for console applications this will result in the default search using the root directory and not the
App_Data folder, i.e. place your Sql Express database file in the root directory of your application.
Bonus points: 10
3. Normalize your database by adding additional tables such as job code, sales information, etc. and using the appropriate joins to process your data.
Bonus points: 10*/