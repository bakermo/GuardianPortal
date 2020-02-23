using GuardianPortal.Domain;
using GuardianPortal.Domain.Character;
using System;
using System.Threading.Tasks;

namespace GuardianPortal.Services.Interfaces
{
    public interface IBungieApiService
    {
        Task<object> GetProfileByMembership(long membershipId, string[] components);
        Task<BungieApiResponse<CharacterResponse>> GetCharactersByMembership(long membershipId);
    }
}
