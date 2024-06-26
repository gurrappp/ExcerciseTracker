﻿using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories;
using ExcerciseTracker.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseTracker.Services
{
    public class ExerciseService(ICardioRepository cardioRepository, Validate validate) : IExerciseService
    {


        public IEnumerable<Cardio> GetAllRecords()
        {
            return cardioRepository.GetAll();
        }

        public Cardio FindExerciseById(int id)
        {
            return cardioRepository.GetById(id);
        }

        public void CreateNewExercise(Cardio cardio)
        { 
            cardioRepository.Add(cardio);
            cardioRepository.SaveChanges();
        }

        public void Update(Cardio cardio) 
        { 
            cardioRepository.Update(cardio);
            cardioRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            cardioRepository.Delete(cardioRepository.GetById(id));
            cardioRepository.SaveChanges();
        }
    }
}
