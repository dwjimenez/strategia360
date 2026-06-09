
using DFast.Seguridad.Api.Models;

namespace DFast.Seguridad.Api.Repositories
{
    public interface IOtpRepository
    {
        Task AddAsync(Otp otp);

        Otp Update(Otp otp);

        Task<Otp> GetAsync(string key, string estado);


    }
}