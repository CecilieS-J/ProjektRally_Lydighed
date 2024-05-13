using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRally_Lydighed.Models
{
    public class Sign
    {
        public int Id { get; set; }
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
        public string Rotation { get; set; }
        public string ImagePath { get; set; }

        // Fremmednøgler for Exercise og Track
       /* public int ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }*/

        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Track Track { get; set; }

      
    }
}
