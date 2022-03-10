using System;
using System.Collections.Generic;

namespace Apartments.Models
{
    public class HousingType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public List<Apartment.Apartment> HousingTypeApartments { get; set; }
    }
}
