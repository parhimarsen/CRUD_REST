using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1_2.Models
{
    public class AccountRepository
    {
        private static AccountRepository repo = new AccountRepository();

        public static AccountRepository Current
        {
            get { return repo; }
        }

        private static List<Account> accounts = new List<Account>()
        {
            new Account(){ NumberOfAccount = "123", AccountId = "1", ClientId = 1},
            new Account(){ NumberOfAccount = "222", AccountId = "2", ClientId = 2},
            new Account(){ NumberOfAccount = "431", AccountId = "3", ClientId = 3}
        };

        public IEnumerable<Account> GetAllAccounts()
        {
            return accounts;
        }

        public Account GetAccount(int id)
        {
            return accounts.Where(_ => _.ClientId == id).FirstOrDefault();
        }

        public IEnumerable<Account> GetAccountsOfClient(int clientId)
        {
            return accounts.Where(_ => _.ClientId == clientId);
        }

        public Account GetAccountOfClient(int clientId, int accountId)
        {
            return GetAccountsOfClient(clientId).Where(_ => _.AccountId == accountId.ToString()).FirstOrDefault();
        }

        public Account CreateAccount(Account acc)
        {
            acc.AccountId = (accounts.Count + 1).ToString();
            accounts.Add(acc);
            return acc;
        }

        public void RemoveAccount(int accountId)
        {
            Account acc = GetAccount(accountId);

            if (acc != null)
            {
                accounts.Remove(acc);
            }
        }

        public bool UpdateAccount(Account acc)
        {
            Account storedAcc = GetAccount(Convert.ToInt16(acc.AccountId));

            if (storedAcc != null)
            {
                storedAcc.NumberOfAccount = acc.NumberOfAccount;
                storedAcc.ClientId = acc.ClientId;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}