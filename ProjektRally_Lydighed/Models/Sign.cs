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
        public byte[] ImageData { get; set; }

        public string ImageContentType { get; set; } // Content Type (f.eks. image/jpeg)
                                                     // Andre relevante egenskaber for billedet, f.eks. filnavn, størrelse osv.

        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Track Track { get; set; }

           
    }
}
