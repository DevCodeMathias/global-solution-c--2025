using exchangeHouse_api.Domain.Enitty;
using exchangeHouse_api.Domain.Interfaces.Service;
using exchangeHouse_api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace exchangeHouse_api.Application.Service
{
    public class BenefitService : IBenefitService
    {
        private readonly AppDbContext _context;
        public BenefitService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task CreateAsync(Benefit benefit)
        {
            _context.WorkBenefits.Add(benefit);
            await _context.SaveChangesAsync();
        }

        public async Task<Benefit> GetDetailsById(Guid Id)
        {
            var benefit = await _context.WorkBenefits
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (benefit == null)
                throw new Exception($"Benefício com ID {Id} não encontrado.");

            return benefit;
        }

        public async Task<List<Benefit>> GetAll()
        {
            var benefit = await _context.WorkBenefits.ToListAsync();

            return benefit;
        }



        public async Task DeleteAsync(Guid id)
        {
            var existing = await _context.WorkBenefits
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
                throw new Exception($"Benefício com ID {id} não encontrado para exclusão.");

            _context.WorkBenefits.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, Benefit updatedBenefit)
        {
            var existing = await _context.WorkBenefits
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
                throw new Exception($"Benefício com ID {id} não encontrado para atualização.");

            existing.Name = updatedBenefit.Name;
            existing.Description = updatedBenefit.Description;
            existing.Category = updatedBenefit.Category;
            existing.Amount = updatedBenefit.Amount;
            existing.Quantity = updatedBenefit.Quantity;
            existing.MetadataJson = updatedBenefit.MetadataJson;
            existing.UpdatedAt = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }

        public async Task<BenefitAcquisitionHistory> AcquireBenefitAsync(string userId, Guid benefitId, int quantity)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Quantidade precisa ser maior que zero.");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                throw new KeyNotFoundException($"Usuário com ID {userId} não encontrado.");

            var benefit = await _context.WorkBenefits.FirstOrDefaultAsync(b => b.Id == benefitId);

            if (benefit == null)
                throw new KeyNotFoundException($"Benefício com ID {benefitId} não encontrado.");

            if (benefit.Quantity < quantity)
                throw new InvalidOperationException("Quantidade solicitada maior que a disponível.");

            var totalCost = benefit.Amount * quantity;

            if (user.WalletBalance < totalCost)
                throw new InvalidOperationException("Saldo insuficiente na carteira do usuário.");

            user.WalletBalance -= totalCost;
            benefit.Quantity -= quantity;
            benefit.UpdatedAt = DateTime.UtcNow;

            var history = new BenefitAcquisitionHistory
            {
                UserId = userId,
                BenefitId = benefitId,
                Quantity = quantity,
                AmountSpent = totalCost,
                CreatedAt = DateTime.UtcNow
            };

            _context.BenefitAcquisitionHistories.Add(history);

            await _context.SaveChangesAsync();

            return history;
        }
    }
}
