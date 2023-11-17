using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProcessNorthwindDB_KellyHumphrey
{
    internal class Program
    {
        /*private static SqlConnection sqlConnection = new
         SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
         "AttachDbFilename=c:\\databases\\northwnd.mdf;" +
         "Integrated Security=True");*/

        

        private static void UpdateRows(SqlConnection sqlConnection)
        {
            try
            {
                // Sql Update Statement
                string updateSql = "UPDATE Employees " +
                "SET FirstName = @FirstName " +
                "WHERE LastName = @LastName";
                SqlCommand UpdateCmd = new SqlCommand(updateSql, sqlConnection);
                // 2. Map Parameters
                UpdateCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 10, "FirstName");
                UpdateCmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 20, "LastName");
                UpdateCmd.Parameters["@FirstName"].Value = "Annabelle";
                UpdateCmd.Parameters["@LastName"].Value = "Jahlberg";
                UpdateCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        private static void DeleteRows(SqlConnection sqlConnection)
        {
            try
            {
                //Create Command objects
                SqlCommand scalarCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", sqlConnection);
                // Execute Scalar Query
                Console.WriteLine("Before Delete, Number of Employees = {0}", scalarCommand.ExecuteScalar());
                // Set up and execute DELETE Command
                //Create Command object
                SqlCommand nonqueryCommand = sqlConnection.CreateCommand();
                nonqueryCommand.CommandText = "DELETE FROM Employees WHERE " + "(LastName='Jahlberg' AND FirstName='Annabelle') OR " +
                "(Lastname='Saxon' AND FirstName='Carey') OR " +
                "(LastName='Gonzales' AND FirstName='Jose')";
                Console.WriteLine("Executing {0}", nonqueryCommand.CommandText);
                Console.WriteLine("Number of rows affected : {0}", nonqueryCommand.ExecuteNonQuery());
                // Execute Scalar Query
                Console.WriteLine("After Delete, Number of Employee = {0}", scalarCommand.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        private static void SelectRows(SqlConnection sqlConnection)
        {
            try
            {
                // Sql Select Query
                string sql = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                string strEmployeeID = "EmployeeID";
                string strFirstName = "FirstName";
                string strLastName = "LastName";
                Console.WriteLine("{0} | {1} | {2}", strEmployeeID.PadRight(10), strFirstName.PadRight(10), strLastName);
                Console.WriteLine("==========================================");
                while (dr.Read())
                {
                    //reading from the datareader
                    Console.WriteLine("{0} | {1} | {2}",
                    dr["EmployeeID"].ToString().PadRight(10),
                    dr["FirstName"].ToString().PadRight(10),
                    dr["LastName"]);
                }
                dr.Close();
                Console.WriteLine("==========================================");
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " +
                ex.ToString());
            }
        }

        private static void InsertRows(SqlConnection sqlConnection)
        {
            //Insert Rows processing
            //Create Command object
            SqlCommand nonqueryCommand = sqlConnection.CreateCommand();
            try
            {
                // Create INSERT statement with named parameters
                nonqueryCommand.CommandText = "INSERT INTO Employees (FirstName, LastName) " +
                "VALUES (@FirstName, @LastName)";
                // Add Parameters to Command Parameters collection
                nonqueryCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 10);
                nonqueryCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 20);
                // Prepare command for repeated execution
                nonqueryCommand.Prepare();
                // Data to be inserted
                string[] firstNames = { "Maxine", "Carey", "Jose" };
                string[] lastNames = { "Jahlberg", "Saxon", "Gonzales" };
                for (int i = 0; i <= 2; i++)
                {
                    nonqueryCommand.Parameters["@FirstName"].Value = firstNames[i];
                    nonqueryCommand.Parameters["@LastName"].Value = lastNames[i];
                    Console.WriteLine("Executing {0}", nonqueryCommand.CommandText);
                    Console.WriteLine("Number of rows affected : {0}", nonqueryCommand.ExecuteNonQuery());
                }
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                // Not used now but you might want some clean up processing in future work
            }
        }

        /*private static void OpenConnection()
        {
            try
            {
                //Modified code to open connection to Northwind Database using "App.config" file
                string connectionString = ConfigurationManager.ConnectionStrings["LocalDBConnection"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                // Open Connection
                sqlConnection.Open();
                Console.WriteLine("Connection Opened");
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
        }*/


        static void Main(string[] args)
        {
            //Modifying code to create connection using app.config file.
            //Code is leveraged from the "C# Code for Video: More SQL Connection Techniques" section.

            var connSettings = ConfigurationManager.ConnectionStrings["NorthwndDB"];
            var connString = connSettings.ConnectionString;
            //To use the ConfigurationManager you will need to add a reference to
            // System.configuration in the References section...
            string dataProvider =
            ConfigurationManager.AppSettings["provider"];

            string connectionString =
            ConfigurationManager.ConnectionStrings["NorthwndDB"].ConnectionString;
            // Get the factory provider.
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
            // Now get the connection object.
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Show error: Connection");
                    return;
                }
                connection.ConnectionString = connectionString;
                connection.Open();
                var sqlConnection = connection as SqlConnection;
                
                //Display Original Data Rows
                Console.WriteLine("\n");
                Console.WriteLine("Display Rows Before Insertion:");
                SelectRows(sqlConnection);
                Console.WriteLine("\n");
                Console.WriteLine("Insert Row operation:***");
                InsertRows(sqlConnection);
                //Display Rows Before Insertion
                Console.WriteLine("\n");
                Console.WriteLine("Display Rows After Insertion:");
                SelectRows(sqlConnection);
                //Update Rows
                Console.WriteLine("\n");
                Console.WriteLine("Perform Update***");
                UpdateRows(sqlConnection);
                //Display Rows Before Insertion
                Console.WriteLine("\n");
                Console.WriteLine("Display Rows After Update:");
                SelectRows(sqlConnection);
                //Clean up with delete of all inserted rows
                Console.WriteLine("\n");
                Console.WriteLine("Clean Up By Deleting Inserted Rows***");
                DeleteRows(sqlConnection);
                //Display Rows After Cleanup
                Console.WriteLine("\n");
                Console.WriteLine("Display Rows After Cleanup:");
                SelectRows(sqlConnection);
                // Close Connection ----- Modified
                connection.Close();
                Console.WriteLine("Connection Closed");
                Console.WriteLine("\nPress <ENTER> to quit...");
                Console.ReadKey();
            }
        }
    }
}
