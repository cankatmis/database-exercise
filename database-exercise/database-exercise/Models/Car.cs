using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_exercise.Models
{
    [Table("cars")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("car_id", TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Model { get; set; }

        public int? BasePrice { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        [NotMapped]
        public virtual Brand Brand { get; set; }

    }
}
