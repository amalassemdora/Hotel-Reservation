using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    [MetadataType(typeof(CustomMeal))]
    public partial class Meal
    {
    }
    public class CustomMeal
    {
        public int meal_id { get; set; }
        [Required(ErrorMessage = "Meal Name is Required")]
        public string meal_name { get; set; }

        [Required(ErrorMessage = "Meal rate in low season is Required")]
        public Nullable<int> low_season { get; set; }

        [Required(ErrorMessage = "Meal rate in hige season is Required")]
        public Nullable<int> high_season { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer> customers { get; set; }
    }
}