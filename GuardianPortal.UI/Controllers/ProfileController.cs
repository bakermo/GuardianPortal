using GuardianPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GuardianPortal.UI.Controllers
{
    [ApiController]
    [Route("/api/profile/")]
    public class ProfileController : ControllerBase
    {
        private readonly IBungieApiService _bungieApiService;
        public ProfileController(IBungieApiService bungieApiService) {
            _bungieApiService = bungieApiService;
        }

        [HttpGet]
        public IActionResult GetProfileDummyData() {
            return new JsonResult(new {
                Message = "it works"
            });
        }

        [HttpGet]
        [Route("membership")]
        public async Task<IActionResult> GetProfileByMembership() {
            long membershipId = 4611686018468065718;
            //string[] components = { "Profiles", "Characters" };
            string[] components = { "Characters" };
            var profile = await _bungieApiService.GetProfileByMembership(membershipId, components);
            return Ok(profile);
        }

        [HttpGet]
        [Route("character")]
        public async Task<IActionResult> GetCharacters() {
            //long membershipId = 4611686018468065718;
            long membershipId = 4611686018487566375; //Jeff
            var characters = await _bungieApiService.GetCharactersByMembership(membershipId);
            return Ok(characters);
        }
    }
}
