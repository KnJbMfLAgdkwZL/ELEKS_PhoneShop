using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO.Frontend;
using Models.Entities;

namespace Application.Interfaces
{
    public interface IAdminPhones
    {
        Task<PhoneSpecFront> GetPhone(string phoneSlug, CancellationToken token);
        Task PhoneInsertOrUpdateAsync(PhoneSpecFront phoneSpecFront, CancellationToken token);
        Task BrandInsertIfNotExistAsync(string brandSlug, CancellationToken token);
        Task<List<Phone>> GetPhonesInStoreAsync(CancellationToken token);
    }
}