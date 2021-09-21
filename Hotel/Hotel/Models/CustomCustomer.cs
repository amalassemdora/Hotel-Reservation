using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    [MetadataType(typeof(CustomCustomer))]
    public partial class customer
    { }
    public class CustomCustomer
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Email must be like[example@example.com]")]
        public string email { get; set; }
        public string country { get; set; }
        public Nullable<int> adults { get; set; }
        public Nullable<int> children { get; set; }
        [Required(ErrorMessage = "Room type is required")]
        public int room_type { get; set; }
        [Required(ErrorMessage = "Meal type is required")]
        public int meal_id { get; set; }

        [Required(ErrorMessage = "Check in date is required")]
        public Nullable<System.DateTime> check_in { get; set; }

        [Required(ErrorMessage = "Check out date is required")]
        public Nullable<System.DateTime> check_out { get; set; }

        [Required(ErrorMessage = "Room number is required")]
        public int room_Num { get; set; }
        public Nullable<decimal> cost { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Room Room { get; set; }
        public virtual Room_Type Room_Type1 { get; set; }
    }
}