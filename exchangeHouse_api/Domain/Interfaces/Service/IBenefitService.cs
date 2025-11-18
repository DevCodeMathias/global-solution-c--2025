using exchangeHouse_api.Domain.Enitty;

namespace exchangeHouse_api.Domain.Interfaces.Service
{
    public interface IBenefitService
    {
        Task<Benefit> GetDetailsById(Guid Id);
        Task<List<Benefit>> GetAll();
        Task CreateAsync(Benefit benefit);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, Benefit updatedBenefit);
        Task<BenefitAcquisitionHistory> AcquireBenefitAsync(string userId, Guid benefitId, int quantity);
        Task<IEnumerable<BenefitAcquisitionHistory>> GetAcquiredBenefitsByUserAsync(string userId);
    }
}

