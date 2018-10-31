﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthaWebService.Model
{
    public class Environment
    {
        public int Id { get; set; }
        public int Oxygen { get; set; }
        public int Nitrogen { get; set; }
        public int CarbonDioxide { get; set; }
        public int Methane { get; set; }
        public int UserId { get; set; }


        public Environment(int id, int oxygen,int nitrogen ,int carbonDioxide, int methane, int userId)
        {
            Id = id;
            Oxygen = oxygen;
            Nitrogen = nitrogen;
            CarbonDioxide = carbonDioxide;
            Methane = methane;
            UserId = userId;

        }

        public Environment()
        {
        }

        public override string ToString()
        {
            return Id + " " + Oxygen + " "+Nitrogen+" " + CarbonDioxide + " " + Methane+ " "+UserId;

        }
    }
}