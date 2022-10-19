using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bankomat.DAL;

namespace Bankomat.Controllers
{
    public class UserAccountsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: UserAccounts
        public async Task<ActionResult> Index()
        {
            ViewBag.UserAccounts = await db.UserAccounts.FirstAsync(x => x.Name == "Garik");
            var banknotes = await db.Banknotes.ToListAsync();
            ViewBag.Banknotes = banknotes.OrderByDescending(x=>x.Banknote);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(int withdraw)
        {
            var account = await db.UserAccounts.FirstAsync(x => x.Name == "Garik");
            var tmp = await db.Banknotes.ToListAsync();
            var banknotes = tmp.OrderByDescending(x => x.Banknote);
            var money = banknotes.Sum(x=>x.Banknote*x.State);
            

            if (withdraw>account.Balance)
            {
                ViewBag.Error = "Non-sufficient funds";
            }
            else if (withdraw>money)
            {
                ViewBag.Error = "Sorry, we do not have enough money";
            }
            else if (withdraw%10!=0)
            {
                ViewBag.Error = "Amount of money should be divided of 10";
            }
            else
            {
                account.Balance -= withdraw;
                List<KeyValuePair<int, int>> BanknoteStates = new List<KeyValuePair<int, int>>();

                foreach (var item in banknotes)
                    {
                        int banknote = item.Banknote;
                        int state = item.State;
                        if (banknote<=withdraw && state>0)
                        {
                            var x = withdraw / banknote > state ? state : withdraw / banknote;
                            BanknoteStates.Add(new KeyValuePair<int, int>(banknote,x));
                            item.State-=x;
                            withdraw -= x * banknote;
                            await db.SaveChangesAsync();
                        }
                    }
                ViewBag.BanknoteStates = BanknoteStates;
                
            }

            
           
            ViewBag.UserAccounts = account;
            ViewBag.Banknotes = banknotes;           

            return View();
        }
    }
}
