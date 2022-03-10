using System;
using System.Collections.Generic;

namespace Apartments.Models.Apartment.ViewModels
{
    public class GetApartmentsViewModel
    {
        public List<Apartment> Apartments { get; set; }
        public int TotalRecords { get; set; }
    }
}
