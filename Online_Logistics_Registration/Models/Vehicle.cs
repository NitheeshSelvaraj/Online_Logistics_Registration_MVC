
using System.ComponentModel.DataAnnotations;

namespace Online_Logistics_Registration.Models
{
    public class Vehicle
    {
        //[Display(Name = "Vehicle ID")]
        //[Required(ErrorMessage = "vehicleID Required")]
        //[Range(10000, 99999)]
        //public int VehicleID { get; set; }

        [Display(Name = "Vehicle Number")]
        [Required(ErrorMessage = "vehicle Number Required")]
        [MaxLength(10)]
        [RegularExpression("^[A-Z]{2}[0-9]{2}[A-Z]{2}[0-9]{4}", ErrorMessage = "Vehicle Number should be eg.(TN35DS8764)")]
        public string VehicleNumber { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "vehicle Type Required")]
        [MaxLength(25)]
        public string VehicleType { get; set; }

        [Display(Name = "Start Location")]
        [Required(ErrorMessage = "Start Location Required")]
        [MaxLength(20)]
        public string StartLocation { get; set; }

        [Display(Name = "Destination Location")]
        [Required(ErrorMessage = "Destination Location Required")]
        [MaxLength(20)]
        public string DestinationLocation { get; set; }

        [Display(Name = "Load Weight(In tons)")]
        [Required(ErrorMessage = "Load weight Required")]
        [Range(12, 99)]
        public int VehicleLoadWeight { get; set; }
    }
}