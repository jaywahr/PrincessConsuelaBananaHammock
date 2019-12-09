namespace PrincessConsuelaBananaHammock.Models
{
    using System.Collections.Generic;

    public class Agent
    {
        public int _Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public int Tier { get; set; }

        public Phone Phone { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
