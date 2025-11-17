using exchangeHouse_api.Domain.ValueObject;

namespace exchangeHouse_api.Domain.Enitty
{
    public class Benefit
    {
        public string User_Id { get; set; }
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BenefitCategoryc Category { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public string MetadataJson { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
