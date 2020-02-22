using System;
using System.Threading.Tasks;

namespace GuardianPortal.Services.Interfaces
{
    public interface IBungieApiService
    {
        Task<object> GetProfileByMembership(long membershipId, string[] components);
    }
}
