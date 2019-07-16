namespace Task1_2.Models
{
    public class UnitOfWork
    {
        public ClientRepository clients
        {
            get
            {
                return ClientRepository.Current;
            }
        }

        public AccountRepository accounts
        {
            get
            {
                return AccountRepository.Current;
            }
        }
    }
}