using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRally_Lydighed.Models
{
    public class Sign
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SignNumber { get; set; }
        public byte[] Image { get; set; } // Gemmer billedet som en byte array
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Rotation { get; set; }
        public int? ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int TrackId { get; set; } // Foreign key til Track
        public Track Track { get; set; }

        /*public int Id { get; set; }
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
        public string Rotation { get; set; }
        public string ImagePath { get; set; }

     
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Track Track { get; set; }
        */

    }
}
