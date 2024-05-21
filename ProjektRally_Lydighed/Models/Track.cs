using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRally_Lydighed.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public ICollection<Sign> Signs { get; set; } = new List<Sign>();
        /* [ForeignKey("CategoryId")]
       public Category? Category { get; set; }

   [ForeignKey("SignId")]
     public ICollection<Sign>? Signs { get; set; }

    public Sign? Sign { get; set; }

        public byte[] Template { get; set; }
        public ICollection<Sign>? Signs { get; set; }*/

    }
}
