using System;
using Apartments.Models.Owner;

namespace Apartments.Models.Apartment
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Address { get; }
        public string Square { get; set; }
        public int? RoomsNumber { get; set; }
        public int ResidentsNumber { get; set; }
        public int HousingTypeId { get; set; }
        public int OwnerId { get; set; }
        public Owner.Owner Owner { get; set; }
        public HousingType HousingType { get; set; }
    }
}
