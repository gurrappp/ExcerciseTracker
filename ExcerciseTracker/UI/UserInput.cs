using ExcerciseTracker.Controllers;
using ExcerciseTracker.Models;
using ExcerciseTracker.Validation;
using OptimalSeatingArrangement.TableVizualisation;
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

        public void Menu()
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
                        List<Cardio> cardioList = controller.ShowAllRecords();
                        TableVisualizationEngine.ShowTable(cardioList, "CardioExercises");
                        break;
                    case 2:
                        GetIdFromUser();
                            
                        break;
                    case 3:
                        var (okId,id) = GetIdFromUser();
                        if (okId)
                            UpdateExercise(id);
                        break;
                    case 5:
                        var newCardio = CreateNewExercise();
                        controller.CreateNewExercise(newCardio);

                        break;
                }
            }
        }
        private (bool,int) GetIdFromUser()
        {
            Console.WriteLine("Write Id of exercise to present:");
            var input = Console.ReadLine();

            var (validInput, id) = validate.ValidateId(input);
            if (!validInput)
            {
                Console.WriteLine("Wrong Input!");
                return (false,-1);
            }
               
            return FindExerciseById(id);
        }

        private (bool,int) FindExerciseById(int id)
        {
            var cardioById = controller.FindExerciseById(id);
            if (cardioById != null)
            {
                TableVisualizationEngine.ShowTable(new List<Cardio> { cardioById }, "CardioExercise");
                return (true,id);
            }
                
            Console.WriteLine("No exercise found with that Id");
            return (false,id);
        }

        private void UpdateExercise(int id)
        {

        }
        

        private Cardio CreateNewExercise()
        {
            
            Console.WriteLine("Write start time of exercise with format: yyyy-MM-dd HH:mm:ss:");
            var value = Console.ReadLine();
            var startTime = validate.ValidateTime(value);
            
            Console.WriteLine("Write end time of exercise with format: yyyy-MM-dd HH:mm:ss:");
            value = Console.ReadLine();

            var endTime = validate.ValidateTime(value);

            TimeSpan timeSpan = endTime.Subtract(startTime);
            DateTime date = DateTime.Parse(timeSpan.ToString());
            var duration = date.ToString("HH:mm:ss");

            Console.WriteLine("Write a comment associated with exercise:");
            var comment = Console.ReadLine();

            return new Cardio 
            {
                DateStart = startTime,
                DateEnd = endTime,
                Duration = duration,
                Comments = comment,
            };

        }
    }
}
