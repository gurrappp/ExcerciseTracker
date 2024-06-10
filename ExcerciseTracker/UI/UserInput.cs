using ExcerciseTracker.Controllers;
using ExcerciseTracker.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.UI
{
    public class UserInput
    {
        private Validate validate;
        private ExerciseController controller;

        public UserInput(Validate validate, ExerciseController controller)
        {
            this.validate = validate;
            this.controller = controller;
        }

        public async Task Menu()
        {

            bool closeApp = false;
            bool validInput = false;
            int option;
            Console.Clear();

            while (!closeApp)
            {
                Console.WriteLine("EXERCISE TRACKER MENU");
                Console.WriteLine("---------------------");
                Console.WriteLine("Options:");
                Console.WriteLine("0 - Exit app");
                Console.WriteLine("1 - Show all exercises");
                Console.WriteLine("2 - Show exercise by id");
                Console.WriteLine("3 - Update an exercise session");
                Console.WriteLine("4 - Delete an exercise session");
                Console.WriteLine("5 - Create new exercise session");
                Console.WriteLine("6 - Start an exercise session");
                Console.WriteLine("7 - Stop an exercise session");


                
                (validInput, option) = validate.ValidateMenuOption(Console.ReadLine());
                if (!validInput)
                    break;

                switch (option)
                {
                    case 0:
                        closeApp = true;
                        break;
                    case 1:
                        controller.ShowAllRecords();
                        break;
                }
            }



        }
    }
}
