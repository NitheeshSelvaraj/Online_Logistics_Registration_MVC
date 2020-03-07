
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Logistics_Registration_Entity
{
    public class Vehicle
    {
        //[Display(Name ="Vehicle ID")]
        //[Required (ErrorMessage="vehicleID Required")]
        //[Range(10000,99999)]
        [Required]
        [Key]
        [Column("Vehicle ID")]
        public int VehicleID { get; set; }

        //[Display(Name = "Vehicle Number")]
        //[Required(ErrorMessage = "vehicle Number Required")]
        //[MaxLength(15)]
        //[RegularExpression("^[A-Z]{2}[0-9]{2}[A-Z]{2}[0-9]{4}", ErrorMessage = "Vehicle Number should be eg.(TN35DS8764)")]
        [Required]
        [Column("Vehicle Number")]
        [MaxLength(10)]
        [Index(IsUnique =true)]
        public string VehicleNumber { get; set; }

        //[Display(Name = "Vehicle Type")]
        //[Required(ErrorMessage = "vehicle Type Required")]
        //[MaxLength(20)]
        [Required]
        [Column("Vehicle Type")]
        //public string VehicleType { get; set; }
        public int VehicleTypeID { get; set; }
        public VehicleType VehicleType { get; set; }

        //[Display(Name = "Start Location")]
        //[Required(ErrorMessage = "Start Location Required")]
        //[MaxLength(15)]
        [Required]
        [Column("Start Location")]
        public string StartLocation { get; set; }

        //[Display(Name = "Destination Location")]
        //[Required(ErrorMessage = "Destination Location Required")]
        //[MaxLength(15)]
        [Required]
        [Column("Destination Location")]
        public string DestinationLocation { get; set; }

        //[Display(Name = "Load Weight(In tons)")]
        //[Required(ErrorMessage = "Load weight Required")]
        //[Range(12,99)]
        [Required]
        [Column("Load Weight")]
        public int VehicleLoadWeight { get; set; }
    }
}
