using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRally_Lydighed.Models
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public int ExerciseNr { get; set; }
      
        public int EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        public Equipment Equipment { get; set; }

        // Navigationsegenskaber
        public ICollection<Sign> Signs { get; set; }
    }
}
