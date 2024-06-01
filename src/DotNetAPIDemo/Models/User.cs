using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DotNetAPIDemo.Models
{
    [Table("post")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("email")]
        public string EMail { get; set; }

        [InverseProperty(nameof(Post.User))]
        [ValidateNever]
        [JsonIgnore]
        public virtual ICollection<Post> Posts { get; set; }
    }
}