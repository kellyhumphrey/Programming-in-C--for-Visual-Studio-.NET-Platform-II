using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace UseCustomAttribute_KellyHumphrey
{
    public class Program
    {


        static void Main(string[] args)
        {

            
            UseWorkoutAttribute myWorkout = new UseWorkoutAttribute();
            myWorkout.doWorkoutStuff();

            Assembly asmInformation;
            asmInformation = Assembly.Load("UseCustomAttribute_KellyHumphrey");
            Console.WriteLine("This is the assembly 'Full Name' information: ");
            Console.WriteLine(asmInformation.FullName);

            Console.WriteLine("\nPress <ENTER> to quit..."); 
            Console.ReadKey();
            
            



            MemberInfo attributeInformation;
            attributeInformation = typeof(UseWorkoutAttribute);


            //
            //
            //
            // I believe it is the code below this point that is producing the error, but I have not been able to resolve.
            //
            //
            //




            object[] attributes = attributeInformation.GetCustomAttributes(false);


            CustomAttributes_KellyHumphrey.WorkoutAttribute myWorkoutAttributes;
            myWorkoutAttributes = (CustomAttributes_KellyHumphrey.WorkoutAttribute)attributes[0];

            Console.WriteLine("Now we are showing the WorkoutAttributes informaiton: ");
            Console.WriteLine(myWorkoutAttributes.WorkoutName);
            Console.WriteLine(myWorkoutAttributes.Category);
            Console.WriteLine(myWorkoutAttributes.RequiredEquipment);

            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();
        }
    }
}
