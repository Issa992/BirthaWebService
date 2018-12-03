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
        private DateTime _dateTime;

        public string DateTime
        {
            get
            {
                return _dateTime.ToString();

            }
            set { _dateTime = System.DateTime.Parse(value); }
        }

        public Health(int id, int bloodPressure, int age, int weight, int userId,string dateTime)
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
