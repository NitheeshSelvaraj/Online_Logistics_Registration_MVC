using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Logistics_Registration.Models
{
    public class VehicleType
    {
        public int VehicleTypeID { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "vehicle Type Required")]
        [MaxLength(25)]
        public string VehicleTypes { get; set; }
    }
}