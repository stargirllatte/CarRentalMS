using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalMS.Models
{
    public class Cars
    {
        [Key]
        public int car_id { get; set; }

        [Required]
        [MaxLength(20)]
        public string car_plate { get; set; }

        [Required]
        [MaxLength(50)]
        public string car_model { get; set; }

        [Required]
        public string car_production_year { get; set; }

        [Required]
        [MaxLength(50)]
        public string car_brand { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal car_price_per_day { get; set; }
    }
}
