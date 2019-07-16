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
        public IEnumerable<Account> GetAllAccounts()
        {
            return repository.accounts.GetAllAccounts();
        }

        // GET api/clients/1
        [Route("{accountId:int}")]
        public Account GetAccount(int accountId)
        {
            return repository.accounts.GetAccount(accountId);
        }

        // POST api/
        [Route("account")]
        public Account PostAccount(Account account)
        {
            return repository.accounts.CreateAccount(account);
        }

        // PUT api/
        [Route("account")]
        public bool PutAccount(Account account)
        {
            return repository.accounts.UpdateAccount(account);
        }

        // DELETE api/
        [Route("account/{accountId:int}")]
        public void DeleteAccount(int accountId)
        {
            repository.accounts.RemoveAccount(accountId);
        }
    }
}
