using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories;
using ExcerciseTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.Controllers
{
    public class ExerciseController(IExerciseService exerciseService)
    {
        //private readonly ICardioRepository<Cardio> _exerciseRepository;

        //public ExerciseController(ICardioRepository<Cardio> exerciseRepository)
        //{
        //    _exerciseRepository = exerciseRepository;
        //}


    }
}
