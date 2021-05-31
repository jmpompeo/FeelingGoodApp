using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Data.Models
{
    public enum Exercise
    { 
        Swim,

        Run,

        Walk, 

        Jog,

        Bike,

        Yoga,

        Strength

    }

    public partial class Exercises
    {
        public Exercise Exercise { get; set; }
    }
}
