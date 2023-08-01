using System.ComponentModel.DataAnnotations;

namespace WebStoreApp.Models
{
    public class Category
    {
        [Key] //doesnt need [Key] if Id is called Id or CategoryId
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; } //with multiple categories, which will be displayed first?

    }
}
