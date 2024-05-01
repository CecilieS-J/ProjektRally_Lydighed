using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;

namespace ProjektRally_Lydighed.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProjektRally_LydighedContext1 context) : base(context)
        {
        }
    }

}

