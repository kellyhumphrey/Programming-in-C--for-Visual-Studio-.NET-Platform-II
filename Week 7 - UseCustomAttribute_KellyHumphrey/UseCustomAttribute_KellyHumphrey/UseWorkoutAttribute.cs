using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UseCustomAttribute_KellyHumphrey
{

    [CustomAttributes_KellyHumphrey.WorkoutAttribute("sculpt", "yoga",
        RequiredEquipment = "yoga mat")]
    public class UseWorkoutAttribute
    {
        
        public UseWorkoutAttribute() { }


        public void doWorkoutStuff()
        {
            Console.WriteLine("This is my \"UseWorkoutAttribute\" class doing stuff");

            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();

        }

    }
}
