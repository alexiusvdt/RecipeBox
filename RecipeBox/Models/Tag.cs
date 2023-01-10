using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Tag
    {
        public int TagId { get; set; }
        public string Title { get; set; }
        public List<RecipeTag> JoinEntities { get; }
        public ApplicationUser User { get; set; } 
    }
}