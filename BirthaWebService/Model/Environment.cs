using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthaWebService.Model
{
    public class Environment
    {
   

        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Humidity { get; set; }
        public decimal Temperatur { get; set; }
        private DateTime _dateTime;

        public string DateTime
        {
            get { return _dateTime.ToString(); }
            set { _dateTime = System.DateTime.Parse(value); }
        }

        public string Location { get; set; }



        public Environment(int id, int userId, decimal humidity, decimal temperatur, string dateTime, string location)
        {
            Id = id;
            UserId = userId;
            Humidity = humidity;
            Temperatur = temperatur;
            DateTime = dateTime;
            Location = location;
        }

        public Environment()
        {
        }

        public override string ToString()
        {
            return Id + " " + UserId + " "+Humidity+" " + Temperatur + " " + DateTime+ " "+Location;

        }
    }
}
