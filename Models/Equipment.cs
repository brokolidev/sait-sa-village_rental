using System;
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
        public string? CategoryName { get; set; }

        public Equipment(int id, string name, string description, double dailyRate, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
            Name = name;
            Description = description;
            DailyRate = dailyRate;
        }

        // constructor for editing 
        public Equipment(int id, string name, string description, double dailyRate, string categoryName, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            DailyRate = dailyRate;
            CategoryName = categoryName;
            CategoryId = categoryId;
        }
    }
}
