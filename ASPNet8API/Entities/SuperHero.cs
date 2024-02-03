namespace ASPNet8API.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string FistName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Palace { get; set; } = String.Empty;
    }
}
