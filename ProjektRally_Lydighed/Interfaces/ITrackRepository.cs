using ProjektRally_Lydighed.Models;

namespace ProjektRally_Lydighed.Interfaces
{
    public interface ITrackRepository : IGenericRepository<Track>
    {
        Task SaveTrackAsync(Track track);
    }
}
