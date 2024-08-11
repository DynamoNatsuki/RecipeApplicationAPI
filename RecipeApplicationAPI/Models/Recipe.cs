using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RecipeApplicationAPI.Models
{
    public class Recipe
    {
        public ObjectId Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "Instructions cannot be longer than 5000 characters.")]
        public string Instructions { get; set; }
    }
}
