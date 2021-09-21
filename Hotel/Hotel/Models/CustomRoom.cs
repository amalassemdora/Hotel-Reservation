using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
	
    [MetadataType(typeof(CustomRoom))]
    public partial class Room
    { }
    public class CustomRoom
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Room type is Required")]
        public Nullable<int> room_type { get; set; }
        public Nullable<bool> reserved { get; set; }

        [Required(ErrorMessage = "Room price is Required")]
        public Nullable<decimal> price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer> customers { get; set; }
        public virtual Room_Type Room_Type1 { get; set; }
    }
}