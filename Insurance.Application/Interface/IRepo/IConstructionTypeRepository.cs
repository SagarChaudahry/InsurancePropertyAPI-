using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.DTO;
using Insurance.Domain.Entity.DbModel;

namespace Insurance.Application.Interface.IRepo
{
    public interface IConstructionTypeRepository
    {
        Task<List<ConstructionType>> GetAllConstructionTypes();
        Task<List<District>> GetAllDistricts();
        Task<string> CreateInsurance(CreateInsuranceRequest request);
        Task<List<Municipality>> GetAllMunicipalities();
        Task<List<PropertyType>> GetAllPropertyTypes();
        Task<List<Province>> GetAllProvinces();
        Task<List<RiskType>> GetAllRiskTypes();
        Task<List<PolicyOP>> GetPolicies(policyFilter filters);





    }
}
