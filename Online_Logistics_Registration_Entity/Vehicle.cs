using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Logistics_Registration_Entity
{
    public class Vehicle
    {
        [Display(Name ="Vehicle ID")]
        [Required (ErrorMessage="vehicleID Required")]
        [Range(10000,99999)]
        public int vehicleID { get; set; }

        [Display(Name = "Vehicle Number")]
        [Required(ErrorMessage = "vehicle Number Required")]
        [MaxLength(15)]
        [RegularExpression("^[A-Z]{2}[0-9]{2}[A-Z]{2}[0-9]{4}", ErrorMessage = "Vehicle Number should be eg.(TN35DS8764)")]
        public string vehicleNumber { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "vehicle Type Required")]
        [MaxLength(20)]
        public string vehicleType { get; set; }

        [Display(Name = "Start Location")]
        [Required(ErrorMessage = "Start Location Required")]
        [MaxLength(15)]
        public string startLocation { get; set; }

        [Display(Name = "Destination Location")]
        [Required(ErrorMessage = "Destination Location Required")]
        [MaxLength(15)]
        public string destinationLocation { get; set; }

        [Display(Name = "Load Weight(In tons)")]
        [Required(ErrorMessage = "Load weight Required")]
        [Range(12,99)]
        public int vehicleLoadWeight { get; set; }
    }
}
