using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookEditor.Models
{
    public class BookPicture
    {
        [Key, ForeignKey("Book")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Img { get; set; }

        [JsonIgnore]
        public virtual Book Book { get; set; } 
    }
}