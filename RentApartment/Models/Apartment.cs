using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentApartment.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public int Florr { get; set; }
        public int Num_Floors { get; set; }
        public int Num_Rooms { get; set; }
        public int Total_Area { get; set; }
        public int LivingArea { get; set; }
        public int KitchenArea { get; set; }
        public int Price { get; set; }
        
        public string rf_UsersId { get; set; }
        //public ApplicationUser Users { get; set; }

        [ForeignKey("TypeHome")]
        public int rf_TypeHomeId { get; set; }
        public TypeHome TypeHome { get; set; }

        [ForeignKey("Address")]
        public int rf_AdressId { get; set; }
        public Address Address { get; set; }

        //public Apartment(int _Florr, int _Num_Floors, int _Num_Rooms, int _Total_Area, int _LivingArea, int _KitchenArea, int _Price, string _rf_UsersId, int _rf_TypeHomeId, int _rf_AdressId)
        //{
        //    Florr = _Florr;
        //    Num_Floors = _Num_Floors;
        //    Num_Rooms = _Num_Rooms;
        //    Total_Area = _Total_Area;
        //    LivingArea = _LivingArea;
        //    KitchenArea = _KitchenArea;
        //    Price = _Price;
        //    rf_UsersId = _rf_UsersId;
        //    rf_TypeHomeId = _rf_TypeHomeId;
        //    rf_AdressId = _rf_AdressId;
        //}
    }
}