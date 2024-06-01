using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DotNetAPIDemo.Models
{
    [Table("post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("user_id")]
        public int UserID { get; set; }

        [InverseProperty(nameof(User.Posts))]
        [ForeignKey(nameof(UserID))]
        [ValidateNever]
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}