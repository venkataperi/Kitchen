using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Models
{
    public class MenuItem
    {
        [Key]
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [Range(1,1000,ErrorMessage ="Price is not good, no one will buy ")]
        public double Price {  get; set; }
        [Display(Name="Food Type")]
        public int? FoodTypeId{ get; set; }
        [ForeignKey("FoodTypeID")]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public FoodType? FoodType { get; set; }

    }
}
