using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories;
using ExcerciseTracker.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.Services
{
    public class ExerciseService(ICardioRepository cardioRepository, Validate validate)   
    {


        public IEnumerable<Cardio> GetAllRecords()
        {
            return cardioRepository.GetAll();
        }

        public void CreateNewExercise(Cardio cardio) {

            
            cardioRepository.Add(cardio);
            
        }
    }
}
