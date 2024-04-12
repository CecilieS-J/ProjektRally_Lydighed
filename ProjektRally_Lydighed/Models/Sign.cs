using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRally_Lydighed.Models
{
    public class Sign
    {
        public int Id { get; set; }
        public int SignNumber { get; set; }


        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

        [ForeignKey("ExerciseId")]
        public Exercise? Exercise { get; set; }
        [ForeignKey("TrackId")]
        public Track? Track { get; set; }

    }
}
