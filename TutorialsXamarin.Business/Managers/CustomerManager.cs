using TutorialsXamarin.Business.BusinessModels;

namespace TutorialsXamarin.Business.Managers
{
    public class CustomerManager
    {
        public Customer GetCustomerById(int customerId)
        {
            if (customerId == 100)
            {
                return new Customer
                {
                    Id=100,
                    FirstName="Mohammed",
                    LastName="Salah"
                };
            }
            return new Customer();
        }
    }
}
