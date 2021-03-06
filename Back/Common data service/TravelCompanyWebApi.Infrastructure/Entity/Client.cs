using System.Collections.Generic;

namespace TravelCompanyWebApi.Infrastructure.Entity
{
    public partial class Client : IEntity<int>
    {
        public Client()
        {
            Passes = new HashSet<Pass>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Pass> Passes { get; set; }
    }
}
