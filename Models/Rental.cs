using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsPrototype.Models
{
    class Rental
    {
        public Rental()
        {
            
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime RentedAt { get; set; }
        public DateTime ReturnedAt { get; set; }
        public double Cost { get; set; }

        public Rental(int id, DateTime createdAt, int customerId, int equipmentId, DateTime rentedAt, DateTime returnedAt, double cost)
        {
            Id = id;
            CreatedAt = createdAt;
            CustomerId = customerId;
            EquipmentId = equipmentId;
            RentedAt = rentedAt;
            ReturnedAt = returnedAt;
            Cost = cost;
        }

        // for saving purposes
        public Rental(int customerId, int equipmentId, DateTime rentedAt, DateTime returnedAt, double cost)
        {
            CustomerId = customerId;
            EquipmentId = equipmentId;
            RentedAt = rentedAt;
            ReturnedAt = returnedAt;
            Cost = cost;
        }
    }
}
