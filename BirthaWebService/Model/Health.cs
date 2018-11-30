using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthaWebService.Model
{
    public class Health
    {
        public int Id { get; set; }
        public int BloodPressure { get; set; }
        public int HeartBeat { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public Health(int id, int bloodPressure, int age, int weight, int userId,DateTime dateTime)
        {
            Id = id;
            BloodPressure = bloodPressure;
            Age = age;
            Weight = weight;
            UserId = userId;
            DateTime = dateTime;
        }

        public Health()
        {
        }

        public override string ToString()
        {
            return Id + " " + BloodPressure + " " + Age + " " + Weight +" "+UserId+" "+DateTime;
        }
    }
}
