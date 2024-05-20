using Microsoft.EntityFrameworkCore;
using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;
using ProjektRally_Lydighed.Repositories;

namespace ProjektRally_Lydighed.Repositories
{
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        public TrackRepository(ProjektRally_LydighedContext1 context) : base(context)
        {
        }


        public async Task SaveTrackAsync(Track track)
        {
            // Gem Track-objektet
            if (track.Id == 0)
            {
                await _context.Track.AddAsync(track);   
            }
            else
            {
                _context.Entry(track).State = EntityState.Modified;
            }

            // Gem ændringerne i databasen
            await _context.SaveChangesAsync();
        }
    }
}
