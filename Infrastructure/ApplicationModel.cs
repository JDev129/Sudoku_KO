using BLMW_Security;
using SudokuMaster.Models;
using System.Data.Entity;

namespace SudokuMaster.Infrastructure
{
    public class ApplicationModel : DbContext
    {
        public ApplicationModel(SecurityCredentials secCred, string database) : 
            base(secCred.ConnectionStringSQL_EF(database, "SudokuMaster.Infrastructure.ApplicationModel"))
        {
            Database.SetInitializer<ApplicationModel>(null);
        }

        public DbSet<ASudokuGame> Games { get; set; }
        public DbSet<SudokuMove> Moves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
