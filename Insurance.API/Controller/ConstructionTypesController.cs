using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Insurance.Application.Interface.IService;
using Insurance.Domain.Entity.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    
        public class ConstructionTypesController(IConstructionTypeServices constructionTypeServices) : ControllerBase
        {
            private readonly IConstructionTypeServices _constructionTypeServices = constructionTypeServices;

            [HttpGet("GetConstructionTypes")]
            [Authorize]

            public async Task<IActionResult> GetConstructionTypes()
            {
                var result = await constructionTypeServices.GetAllConstructionTypes();
                return Ok(result);
            }
        [HttpGet("GetDistricts")]
        [Authorize]
        public async Task<IActionResult> GetDistricts()
        {
            var result = await _constructionTypeServices.GetAllDistricts();
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateInsuranceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _constructionTypeServices.CreateInsurance(request);

            return Ok(result);
        }
        [HttpGet("GetMunicipalities")]
        [Authorize]
        public async Task<IActionResult> GetMunicipalities()
        {
            var result = await _constructionTypeServices.GetAllMunicipalities();
            return Ok(result);
        }
        [HttpGet("GetProperty"), Authorize]
        public IActionResult GetProperty()
        {
            try
            {
                return Ok("This is Property API");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPropertyTypes")]
        [Authorize]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var result = await _constructionTypeServices.GetAllPropertyTypes();
            return Ok(result);
        }
        [HttpGet("GetProvinces")]
        [Authorize]
        public async Task<IActionResult> GetProvinces()
        {
            var result = await _constructionTypeServices.GetAllProvinces();
            return Ok(result);
        }

        [HttpGet("GetRiskTypes")]
        [Authorize]
        public async Task<IActionResult> GetRiskTypes()
        {
            var result = await _constructionTypeServices.GetAllRiskTypes();
            return Ok(result);
        }

        [HttpGet("GetPolicies")]
        [Authorize]
        public async Task<IActionResult> GetPolicies([FromQuery] policyFilter filters)
        {

            return Ok(await _constructionTypeServices.GetPolicies(filters));
        }

    }
    }





  
