using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;

namespace ProjektRally_Lydighed.Repositories
{
    public class SignRepository : GenericRepository<Sign>, ISignRepository
    {
        public SignRepository(ProjektRally_LydighedContext1 context) : base(context)
        {
        }

    }
}
