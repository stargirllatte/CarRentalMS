using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRentalMS.Models
{
    public class Rent
    {
        [Key]
        public int car_id { get; set; }

        [Required]
        [MaxLength(20)]
        public string car_plate { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string customer_name { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string customer_id { get; set; } = string.Empty;

        [Required]
        public DateTime car_rental_date { get; set; }

        [Required]
        public DateTime car_return_date { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal total_cost_rent { get; set; }
    }
}
