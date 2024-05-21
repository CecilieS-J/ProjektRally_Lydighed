using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRally_Lydighed.Models
{
    public class Exercise
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public int ExerciseNr { get; set; }

        // Foreign key to Track
        public int TrackId { get; set; }
        public Track Track { get; set; }

        // Foreign key to Sign
        public int SignId { get; set; }
        public Sign Sign { get; set; }
        // Constructor for at initialisere ExerciseNr
        public Exercise()
        {
            // Default til 0, hvis ikke angivet
            ExerciseNr = 0;
        }
        /*
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

       public string Name { get; set; }
       public string Description { get; set; } = string.Empty;
       public string? Image { get; set; } = string.Empty;
       public int ExerciseNr { get; set; }

         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExercisetId { get; set; } // Ny kolonne der genereres af databasen

        public int EquipmentId { get; set; }
          [ForeignKey("EquipmentId")]
          public Equipment Equipment { get; set; }

          // Navigationsegenskaber
          public ICollection<Sign> Signs { get; set; }*/
    }
}
