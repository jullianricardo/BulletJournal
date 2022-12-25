using BulletJournal.Data.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Infrastructure
{
    public class BaseContext : IdentityDbContext<User>
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BulletJournal;Data Source=LAPTOP-RRVRFLO5;Trust Server Certificate=True");
        //}
    }
}
