namespace PrincessConsuelaBananaHammock.Models
{
    using System;
    using System.Linq;

    public class Customer
    {
        public int _Id { get; set; }

        public int Agent_id { get; set; }

        public Guid Guid { get; set; }

        public bool IsActive { get; set; }

        public string Balance { get; set; }

        public int Age { get; set; }

        public string EyeColor { get; set; }

        public Name Name { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string CityState
        {
            get
            {
                var addressSplit = Address.Split(',').Select(x => x.Trim()).ToList();
                return $"{addressSplit[1]}, {addressSplit[2]}";
            }
        }

        public DateTime Registered { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string[] Tags { get; set; }
    }
}
