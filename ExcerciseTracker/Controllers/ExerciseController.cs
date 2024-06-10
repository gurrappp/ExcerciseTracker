using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories;
using ExcerciseTracker.Services;
using OptimalSeatingArrangement.TableVizualisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.Controllers
{
    
    public class ExerciseController(ExerciseService exerciseService, ICardioRepository cardioRepository)
    {

        public void ShowAllRecords()
        {
            var list = cardioRepository.GetAll();

            TableVisualizationEngine.ShowTable(list.ToList(), "CardioExercises", "");
            
        }
        //private readonly ICardioRepository<Cardio> _exerciseRepository;

        //public ExerciseController(ICardioRepository<Cardio> exerciseRepository)
        //{
        //    _exerciseRepository = exerciseRepository;
        //}


    }
}
