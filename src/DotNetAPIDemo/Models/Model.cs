using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DotNetAPIDemo.Models
{
    [Table("model")]
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("manufacturer_id")]
        public int ManufacturerID { get; set; }

        [ValidateNever]
        [JsonIgnore]
        [ForeignKey(nameof(ManufacturerID))]
        [InverseProperty(nameof(Manufacturer.Models))]
        public virtual Manufacturer Manufacturer { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}