using exchangeHouse_api.Domain.Enitty;

namespace exchangeHouse_api.Domain.Interfaces.Service
{
    public interface IBenefitService
    {
        Task<Benefit> GetDetailsById(Guid Id);
        Task CreateAsync(Benefit benefit);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, Benefit updatedBenefit);
    }
}
