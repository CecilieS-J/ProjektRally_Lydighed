using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjektRally_Lydighed.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ProjektRally_LydighedUser class
public class ProjektRally_Lydighed1 : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

