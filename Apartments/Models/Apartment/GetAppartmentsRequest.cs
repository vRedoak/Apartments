using System;
using Apartments.Models.Apartment.ViewModels;
using Apartments.Models.Owner;

namespace Apartments.Models.Apartment
{
    public class GetAppartmentsRequest
    {
        public string Address { get; set; }
        public int? RoomsNumber { get; set; }
        public OwnerViewModel Owner { get; set; }
    }
}
