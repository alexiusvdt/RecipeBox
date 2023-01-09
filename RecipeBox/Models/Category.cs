using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Recipe> Recipes { get; set; }
  }
}