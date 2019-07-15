using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1_2.Models;

namespace Task1_2.Controllers
{
    [RoutePrefix("Clients")]
    public class HomeController : Controller
    {
        static List<Client> clients = new List<Client>()
        {
            new Client(){ Name = "Arseny", ClientId = "1" },
            new Client(){ Name = "Pavel", ClientId = "2" },
            new Client(){ Name = "Youra", ClientId = "3" }
        };

        private static List<Account> accounts = new List<Account>()
        {
            new Account(){ NumberOfAccount = "123", AccountId = "1", ClientId = 1},
            new Account(){ NumberOfAccount = "222", AccountId = "2", ClientId = 2},
            new Account(){ NumberOfAccount = "431", AccountId = "3", ClientId = 3}
        };

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        [Route("GetClient")]
        [Route("GetClient/{clientId:int}")]
        public ActionResult GetClient(int? clientId)
        {
            if (clientId == null)
            {
                return Json(clients, JsonRequestBehavior.AllowGet);
            }
            var client = clients.FirstOrDefault(_ => _.ClientId == clientId.ToString());

            if (client == null)
            {
                throw new HttpException(404, "not found");
            }

            return Json(client, JsonRequestBehavior.AllowGet);
        }

        [Route("GetClient/{clientId:int}/GetAccount")]
        [Route("GetClient/{clientId:int}/GetAccount/{accountId:int}")]
        public ActionResult GetAccount(int? clientId, int? accountId)
        {
            if (clientId == null)
            {
                return Json(clients, JsonRequestBehavior.AllowGet);
            }
            var client = clients.FirstOrDefault(_ => _.ClientId == clientId.ToString());

            if (client == null)
            {
                throw new HttpException(404, "not found");
            }
            else
            {
                var allAccountsOfClient = accounts.Where(_ => _.ClientId == clientId);
                if (accountId == null)
                {
                    return Json(allAccountsOfClient, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var accountOfClient = allAccountsOfClient.FirstOrDefault(_ => _.AccountId == accountId.ToString());
                    return Json(accountOfClient, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public ActionResult DeleteStudent(int? id)
        {
            if (id != null)
            {
                clients.Remove(clients.FirstOrDefault(_ => _.ClientId == id.ToString()));
            }
            return new HttpStatusCodeResult(204);
        }

    }
}
