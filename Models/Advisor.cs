namespace ApexaAssignment.Models
{
    public class Advisor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public HealthStatusType HealthStatus { get; set; }
    }
}
