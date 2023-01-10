using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    // [Required(ErrorMessage = "The recipe's name can't be empty!")]
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    // [RegularExpression("([1-5]*)")]
    public int Rating { get; set; }
    public List<RecipeTag> JoinEntities { get;}
    public ApplicationUser User { get; set; }
  }
}