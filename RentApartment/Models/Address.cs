using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentApartment.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Apartment { get; set; }
    }
}