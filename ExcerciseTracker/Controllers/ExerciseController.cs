using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories;
using ExcerciseTracker.Services;
using OptimalSeatingArrangement.TableVizualisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.Controllers
{
    
    public class ExerciseController(ExerciseService exerciseService)
    {

        public List<Cardio> ShowAllRecords()
        {
            var cardioList = exerciseService.GetAllRecords().ToList();

            return cardioList;

            //TableVisualizationEngine.ShowTable(cardioList, "CardioExercises", "");
            
        }
        //private readonly ICardioRepository<Cardio> _exerciseRepository;

        //public ExerciseController(ICardioRepository<Cardio> exerciseRepository)
        //{
        //    _exerciseRepository = exerciseRepository;
        //}

        public Cardio? FindExerciseById(int id)
        {
            var cardio = exerciseService.FindExerciseById(id);
            return cardio;
        }


        public void CreateNewExercise(Cardio newCardio)
        {
            exerciseService.CreateNewExercise(newCardio);

            //return cardio;
        }

    }
}
