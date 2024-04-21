using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;
using ProjektRally_Lydighed.Repositories;

namespace ProjektRally_Lydighed.Repositories
{
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        public TrackRepository(ProjektRally_LydighedContext context) : base(context)
        {
        }
    }
}
