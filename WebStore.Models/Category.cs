using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class Category
{
    [Key] //doesnt need [Key] if Id is called Id or CategoryId
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("Category Name")]
    public string Name { get; set; }
    [DisplayName("Display Order")] //for å gjøre det lette i UI å bruke labels. 
    [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100.")]
    public int DisplayOrder { get; set; } //with multiple categories, which will be displayed first?

}
