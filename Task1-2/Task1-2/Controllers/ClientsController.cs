using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Task1_2.Models;

namespace Task1_2.Controllers
{
    [RoutePrefix("clients")]
    public class ClientsController : ApiController
    {
        private UnitOfWork repository = new UnitOfWork();

        // GET api/clients
        [Route("")]
        public IEnumerable<Client> GetAllClients()
        {
            return repository.clients.GetAllClients();
        }

        // GET api/clients/1
        [Route("{clientId:int}")]
        public Client GetClient(int clientId)
        {
            return repository.clients.GetClient(clientId);
        }

        // POST api/
        public Client PostClient(Client client)
        {
            return repository.clients.CreateClient(client);
        }

        // PUT api/
        public bool PutClient(Client client)
        {
            return repository.clients.UpdateClient(client);
        }

        // DELETE api/
        public void DeleteClient(int clientId)
        {
            repository.clients.RemoveClient(clientId);
        }
    }
}
