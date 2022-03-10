using System;
using System.Collections.Generic;
using Apartments.Models.Apartment;

namespace Apartments.Models.Owner
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string PlacceOfWork { get; set; }

        public List<Apartment.Apartment> OwnerApartments { get; set; }
    }
}
