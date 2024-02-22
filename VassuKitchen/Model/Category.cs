using System.ComponentModel.DataAnnotations;

namespace VassuKitchen.Model;

public class Category
{
    [Key]
   
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Display(Name="Display Order")]
    [Range(1, 100,ErrorMessage ="The display order is out of range")]
    public int DisplayOrder { get; set; }

}
