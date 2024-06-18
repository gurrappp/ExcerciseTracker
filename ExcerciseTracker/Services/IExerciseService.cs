using ExcerciseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.Services
{
    public interface IExerciseService
    {
        IEnumerable<Cardio> GetAllRecords();
        Cardio FindExerciseById(int id);
        void CreateNewExercise(Cardio cardio);
        void Update(Cardio cardio);
        void Delete(int id);
    }
}
