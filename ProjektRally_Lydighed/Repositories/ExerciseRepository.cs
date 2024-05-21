using Microsoft.EntityFrameworkCore;
using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;
using ProjektRally_Lydighed.Repositories;

namespace ProjektRally_Lydighed.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository

    {
        public ExerciseRepository(ProjektRally_LydighedContext1 context) : base(context)
        {
           

        }
      
    }
}
