using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Identity
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
    }
}
