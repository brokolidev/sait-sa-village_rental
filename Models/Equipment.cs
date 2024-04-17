﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsPrototype.Models
{
    class Equipment
    {
        public Equipment()
        {
            
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double DailyRate { get; set; }

        public Equipment(int id, int categoryId, string name, string description, double dailyRate)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            DailyRate = dailyRate;
        }
    }
}
