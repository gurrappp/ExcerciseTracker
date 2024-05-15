using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.Controllers
{
    internal class ExerciseController
    {
        private readonly IExerciseRepository<Running> _exerciseRepository;

        public ExerciseController(IExerciseRepository<Running> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }


    }
}
