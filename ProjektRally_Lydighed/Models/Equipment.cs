using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjektRally_Lydighed.Models
{
    public class Equipment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

    }
}
