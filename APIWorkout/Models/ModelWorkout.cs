using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace APIWorkout.Models
{
    public class ModelWorkout
    {
        public ModelWorkout(Workout workout)
        {
            id = workout.id;
            day = workout.day;
            wotkout = workout.wotkout;
            trainer = workout.trainer;
            image = workout.image;
        }
        public int id { get; set; }
        public string day { get; set; }
        public string wotkout { get; set; }
        public string trainer { get; set; }
        public string image { get; set; }
    }
}