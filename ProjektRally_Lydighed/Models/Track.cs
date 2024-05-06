using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRally_Lydighed.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Comment { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }


       [ForeignKey("CategoryId")]
       public Category? Category { get; set; }
       public ICollection<Sign>? Signs { get; set; }
        public byte[] Template { get; set; }
    }
}
