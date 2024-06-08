using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DotNetAPIDemo.Models
{
    [Table("vehicle")]
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("user_email")]
        public string UserEmail { get; set; }

        [Column("model_id")]
        public int ModelID { get; set; }

        [ValidateNever]
        [JsonIgnore]
        [ForeignKey(nameof(ModelID))]
        [InverseProperty(nameof(Model.Vehicles))]
        public virtual Model Model { get; set; }

        [Column("model_year")]
        public int ModelYear { get; set; }

        [Column("colour")]
        public string Colour { get; set; }

        [Column("purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [Column("sale_date")]
        public DateTime SaleDate { get; set; }
    }
}