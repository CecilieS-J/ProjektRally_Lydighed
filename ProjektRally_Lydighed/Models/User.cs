using ProjektRally_Lydighed.Models;

namespace ProjektRally_Lydighed.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
