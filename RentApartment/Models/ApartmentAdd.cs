using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentApartment.Models
{
    public class ApartmentAdd
    {
        [Required]
        [Display(Name = "Этаж")]
        public int Florr { get; set; }
        [Required]
        [Display(Name = "Кол-во этажей")]
        public int Num_Floors { get; set; }
        [Required]
        [Display(Name = "Кол-во комнат")]
        public int Num_Rooms { get; set; }
        [Required]
        [Display(Name = "Общая площадь")]
        public int Total_Area { get; set; }
        [Required]
        [Display(Name = "Жилая площадь")]
        public int LivingArea { get; set; }
        [Required]
        [Display(Name = "Площаль кухни")]
        public int KitchenArea { get; set; }
        [Required]
        [Display(Name = "Стоимость")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Тип дома")]
        public int rf_TypeHomeId { get; set; }
        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Область")]
        public string Area { get; set; }
        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Район")]
        public string District { get; set; }
        [Required]
        [Display(Name = "Улица")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Дом")]
        public int House { get; set; }
        [Required]
        [Display(Name = "Квартира")]
        public int Apartment { get; set; }

        public List<SelectListItem> GetTypeHomeList()
        {
            ApplicationContext db = new ApplicationContext();
            var typesHome = db.TypesHome.ToList();
            int cnt = typesHome.Count;
            List<SelectListItem> l = new List<SelectListItem>(cnt);
            foreach (var type in typesHome)
            {
                l.Add(new SelectListItem() { Text = type.Name, Value = type.Id.ToString() });
            }
            return l;
        }
    }
}