using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.Interface.IRepo;
using Insurance.Application.Interface;
using Insurance.Domain.Entity.DbModel;
using Insurance.Domain;
using Insurance.Application.Interface.IService;
using Insurance.Application.DTO;

namespace Insurance.Application.Service
{

    public class ConstructionTypeServices(IConstructionTypeRepository constructionTypeRepo) : IConstructionTypeServices
    {
        private readonly IConstructionTypeRepository propertyTypeRepo = constructionTypeRepo;

        public async Task<ApiResponse<List<ConstructionType>>> GetAllConstructionTypes()
        {
            var results = await constructionTypeRepo.GetAllConstructionTypes();
            ApiResponse<List<ConstructionType>> response = new ApiResponse<List<ConstructionType>>
            {
                result = results,
                message = "Property types retrieved successfully",
                responseCode = "200"

            };
            return response;
        }
        public async Task<ApiResponse<List<District>>> GetAllDistricts()
        {
            var results = await constructionTypeRepo.GetAllDistricts();

            return new ApiResponse<List<District>>
            {
                result = results,
                message = "Districts retrieved successfully",
                responseCode = "200"
            };
        }
        public async Task<ApiResponse<string>> CreateInsurance(CreateInsuranceRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new ApiResponse<string>
                    {
                        responseCode = "400",
                        message = "Request cannot be null.",
                        result = null
                    };
                }

                if (request.InsuredPerson == null)
                {
                    return new ApiResponse<string>
                    {
                        responseCode = "400",
                        message = "Insured person is required.",
                        result = null
                    };
                }

                if (request.Properties == null)
                {
                    return new ApiResponse<string>
                    {
                        responseCode = "400",
                        message = "At least one property is required.",
                        result = null
                    };
                }

                var result = await constructionTypeRepo.CreateInsurance(request);

                return new ApiResponse<string>
                {
                    responseCode = "200",
                    message = "Insurance created successfully.",
                    result = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>
                {
                    responseCode = "500",
                    message = ex.InnerException?.Message ?? ex.Message,
                    result = null
                };
            }
        }
        public async Task<ApiResponse<List<Municipality>>> GetAllMunicipalities()
        {
            var results = await constructionTypeRepo.GetAllMunicipalities();

            return new ApiResponse<List<Municipality>>
            {
                result = results,
                message = "Municipalities retrieved successfully",
                responseCode = "200"
            };
        }
        public async Task<ApiResponse<List<PropertyType>>> GetAllPropertyTypes()
        {
            var results = await constructionTypeRepo.GetAllPropertyTypes();
            ApiResponse<List<PropertyType>> response = new ApiResponse<List<PropertyType>>
            {
                result = results,
                message = "Property types retrieved successfully",
                responseCode = "200"

            };
            return response;
        }
        public async Task<ApiResponse<List<Province>>> GetAllProvinces()
        {
            var results = await constructionTypeRepo.GetAllProvinces();

            return new ApiResponse<List<Province>>
            {
                result = results,
                message = "Provinces retrieved successfully",
                responseCode = "200"
            };
        }
        public async Task<ApiResponse<List<RiskType>>> GetAllRiskTypes()
        {
            var results = await constructionTypeRepo.GetAllRiskTypes();

            return new ApiResponse<List<RiskType>>
            {
                result = results,
                message = "Risk types retrieved successfully",
                responseCode = "200"
            };
        }

        public async Task<ApiResponse<List<PolicyOP>>> GetPolicies(policyFilter filters)
        {
            var results = await constructionTypeRepo.GetPolicies(filters);

            return new ApiResponse<List<PolicyOP>>
            {
                result = results,
                message = "Policy were retrieved successfully",
                responseCode = "200"
            };
        }





    }
}