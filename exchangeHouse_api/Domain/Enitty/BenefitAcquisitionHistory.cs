namespace exchangeHouse_api.Domain.Enitty
{
    public class BenefitAcquisitionHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public Guid BenefitId { get; set; }
        public int Quantity { get; set; }
        public decimal AmountSpent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Benefit Benefit { get; set; }
    }
}
