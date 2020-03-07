using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Logistics_Registration_Entity
{
    public class VehicleType
    {
        [Required]
        [Key]
        [Column("Vehicle Type ID")]
        public int VehicleTypeID { get; set; }

        [Required]
        [Column("Vehicle Type")]
        [MaxLength(25)]
        [Index(IsUnique =true)]
        public string VehicleTypes { get; set; }
    }
}
