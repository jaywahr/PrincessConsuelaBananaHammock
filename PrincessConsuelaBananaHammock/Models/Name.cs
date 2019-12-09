namespace PrincessConsuelaBananaHammock.Models
{
    public class Name
    {
        public string First { get; set; }

        public string Last { get; set; }

        public string FullName => $"{Last}, {First}";
    }
}
