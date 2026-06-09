using System;
using System.Threading.Tasks;
//using DFast.Common.Mongo;
using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DFast.Seguridad.Api.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly ContextDatabase _seguridadfContext;

        public OtpRepository(ContextDatabase seguridadfContext)
        {
            _seguridadfContext = seguridadfContext;
        }


        
        public async Task AddAsync(Otp otp)
            =>  await _seguridadfContext.Otp.AddAsync(otp);

        public Otp Update(Otp otp)
        {
            _seguridadfContext.Otp.Update(otp);
            return otp;
        }

        public async Task<Otp> GetAsync(string key, string estado)
           => await  _seguridadfContext.Otp
            .OrderByDescending(x => x.IdOtp)
            .FirstOrDefaultAsync(x => x.Dato == key && x.Estado == estado);
    }
}