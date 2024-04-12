using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjektRally_Lydighed.Models
{
    public class Category
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        public CategoryType Type { get; set; }
        public int NumberOfExercise { get; set; }
        public string Rules { get; set; }

        public ICollection<Track>? Tracks { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }
    }
}
