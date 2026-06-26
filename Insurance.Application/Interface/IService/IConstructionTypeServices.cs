using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Entity.DbModel;
using Insurance.Domain;
using Insurance.Application.DTO;

namespace Insurance.Application.Interface.IService
{
    public interface IConstructionTypeServices
    {
        Task<ApiResponse<List<ConstructionType>>> GetAllConstructionTypes();
        Task<ApiResponse<List<District>>> GetAllDistricts();
        Task<ApiResponse<string>> CreateInsurance(CreateInsuranceRequest request);
        Task<ApiResponse<List<Municipality>>> GetAllMunicipalities();
        Task<ApiResponse<List<Province>>> GetAllProvinces();
        Task<ApiResponse<List<RiskType>>> GetAllRiskTypes();
        Task<ApiResponse<List<PropertyType>>> GetAllPropertyTypes();
        Task<ApiResponse<List<PolicyOP>>> GetPolicies(policyFilter filters);






    }
}
