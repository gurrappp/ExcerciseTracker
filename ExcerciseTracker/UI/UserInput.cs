using ExcerciseTracker.Controllers;
using ExcerciseTracker.Models;
using ExcerciseTracker.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

                bool okId = false;
                int id = 0;
                Cardio? cardio = null;
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
                        (okId,id) = GetIdFromUser();
                        if (okId)
                        {
                            var (newStartTime,newEndTime,comment) = UpdateExercise(id);
                            controller.UpdateExercise(id, newStartTime, newEndTime, comment);
                        }
                        Console.Clear();
                        break;
                    case 4:
                        (okId, id) = GetIdFromUser();
                        if (okId)
                        {
                            if(DeleteExercise())
                                controller.DeleteExercise(id);
                        }
                        Console.Clear();
                        break;
                    case 5:
                        cardio = CreateNewExercise();
                        controller.CreateNewExercise(cardio);
                        Console.Clear();
                        break;
                    case 6:
                        controller.StartNewExercise(StartNewExercise());
                        break;
                    case 7:
                        (okId, id) = GetIdFromUser();
                        if (okId)
                        {
                            cardio = controller.FindExerciseById(id);
                            if(cardio != null)
                            {
                                controller.EndExercise(EndExercise(cardio));
                            }
                                
                            //controller.EndExercise(EndExercise(id));
                        }
                        Console.Clear();
                        
                        break;
                }
            }
        }
        private (bool,int) GetIdFromUser()
        {
            Console.WriteLine("Write Id of exercise you want to see:");
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

        private (DateTime?,DateTime?,string?) UpdateExercise(int id)
        {
            DateTime? newStartTime = null;
            DateTime? newEndTime = null;
            string? comment = null;

            Console.WriteLine("Write new start time  yyyy-MM-dd HH:mm:ss : (0 to keep value)");
            var input = Console.ReadLine();
            if (input != "0")
                newStartTime = validate.ValidateTime(input);

            Console.WriteLine("Write new end time  yyyy-MM-dd HH:mm:ss : (0 to keep value)");
            input = Console.ReadLine();
            if (input != "0")
                newEndTime = validate.ValidateTime(input);

            Console.WriteLine("Write new Comment: (0 to keep value)");
            input = Console.ReadLine();
            if (input != "0")
                comment = input;

            return (newStartTime, newEndTime, comment);
        }

        public bool DeleteExercise()
        {
            Console.WriteLine("Do you want to delete this exercise?  y/n ");
            var input = Console.ReadLine();
            
            return (input == "y" || input == "Y");
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

        private Cardio StartNewExercise() =>  new Cardio { DateStart = DateTime.Now};

        private Cardio EndExercise(Cardio cardio)
        {
            cardio.DateEnd = DateTime.Now;

            TimeSpan timeSpan = cardio.DateEnd.Value.Subtract(cardio.DateStart.Value);
            DateTime date = DateTime.Parse(timeSpan.ToString());
            cardio.Duration = date.ToString("HH:mm:ss");

            Console.WriteLine("Write a comment associated with exercise:");
            cardio.Comments = Console.ReadLine();

            return cardio;
        }
    }
}
