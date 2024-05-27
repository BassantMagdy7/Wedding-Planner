using Microsoft.AspNetCore.Identity; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class ApplicationUser : IdentityUser 
    {

            public string Role { get; set; }
            public string Gender { get; set; }
            public string UserLocation { get; set; }
            public string SSN { get; set; }
    }
}
