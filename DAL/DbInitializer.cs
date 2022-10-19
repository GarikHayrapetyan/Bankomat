using Bankomat.Models;
using System.Collections.Generic;

namespace Bankomat.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var userAccount = new UserAccount { Name = "Garik", Surname = "Hayrapetyan", Balance = 7654 };
            context.UserAccounts.Add(userAccount);
            context.SaveChanges();

            var banknotes = new List<BanknoteDetail> {
                new BanknoteDetail {Banknote=200, Name = "zl", State=5 },
                new BanknoteDetail {Banknote=100, Name = "zl", State=5 },
                new BanknoteDetail {Banknote=50, Name = "zl", State=5 },
                new BanknoteDetail {Banknote=20, Name = "zl", State=5 },
                new BanknoteDetail {Banknote=10, Name = "zl", State=5 }
            };

            context.Banknotes.AddRange(banknotes);
            context.SaveChanges();
        }
    }
}
