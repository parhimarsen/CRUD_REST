using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task1_2.Models;

namespace Task1_2.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountsController : ApiController
    {
        private UnitOfWork repository = new UnitOfWork();

        // GET api/accounts
        [Route("")]
        public IEnumerable<Account> GetAllClients()
        {
            return repository.accounts.GetAllAccounts();
        }

        // GET api/clients/1
        [Route("{accountId:int}")]
        public Account GetClient(int accountId)
        {
            return repository.accounts.GetAccount(accountId);
        }

        // POST api/
        public Account PostClient(Account account)
        {
            return repository.accounts.CreateAccount(account);
        }

        // PUT api/
        public bool PutClient(Account account)
        {
            return repository.accounts.UpdateAccount(account);
        }

        // DELETE api/
        public void DeleteClient(int accountId)
        {
            repository.accounts.RemoveAccount(accountId);
        }
    }
}
