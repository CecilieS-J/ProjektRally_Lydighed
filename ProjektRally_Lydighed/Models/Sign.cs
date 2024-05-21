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

     
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Track Track { get; set; }

      
    }
}
