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

        public void StartNewExercise(Cardio newCardio)
        {
            exerciseService.CreateNewExercise(newCardio);
        }

        public void EndExercise(Cardio cardio)
        {
            exerciseService.Update(cardio);
        }

        public void UpdateExercise(int id, DateTime? newStartTime, DateTime? newEndTime, string? comment)
        {
            var cardio = exerciseService.FindExerciseById(id);
            
            if(newStartTime != null) cardio.DateStart = newStartTime;
            if(newEndTime != null) cardio.DateEnd = newEndTime;
            if(comment != null) cardio.Comments = comment;
            exerciseService.Update(cardio);
        }

        public void DeleteExercise(int id)
        {
            exerciseService.Delete(id);
        }

    }
}
