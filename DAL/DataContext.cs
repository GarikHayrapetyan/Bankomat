using System.Data.Entity;
using Bankomat.Models;

namespace Bankomat.DAL
{
    public class DataContext: DbContext
    {
        public DbSet<BanknoteDetail> Banknotes { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public DataContext() :base("ConnectionString")
        {

        }
    }
}
