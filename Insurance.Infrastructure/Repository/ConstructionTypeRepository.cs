using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.DTO;
using Insurance.Application.Interface.IRepo;
using Insurance.Application.Interface.IService;
using Insurance.Domain.Entity.DbModel;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repository
{

    public class ConstructionTypeRepository(ApplicationDBFactory dbcontext) : IConstructionTypeRepository
    {
        private readonly ApplicationDBFactory _dbcontext = dbcontext;

        public async Task<List<ConstructionType>> GetAllConstructionTypes()
        {

            var ConstructionType = await _dbcontext.ConstructionTypes.ToListAsync();
            return (ConstructionType);
        }
        public async Task<List<District>> GetAllDistricts()
        {
            return await _dbcontext.Districts.ToListAsync();
        }
        public async Task<string> CreateInsurance(CreateInsuranceRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            await using var transaction = await _dbcontext.Database.BeginTransactionAsync();

            try
            {
                // Save Insured Person
                request.InsuredPerson.CreatedAt = DateTime.UtcNow;
                request.InsuredPerson.UpdatedAt = null;

                await _dbcontext.InsuredPersons.AddAsync(request.InsuredPerson);
                await _dbcontext.SaveChangesAsync();

                // Save Properties


                request.Properties.CreatedAt = DateTime.UtcNow;
                request.Properties.UpdatedAt = null;


                await _dbcontext.Properties.AddAsync(request.Properties);
                await _dbcontext.SaveChangesAsync();

                // Save Policy


                request.Policy.InsuredId = request.InsuredPerson.InsuredId;
                request.Policy.PropertyId = request.Properties.PropertyId;

                request.Policy.PolicyStatusId = 1;
                await _dbcontext.Policies.AddAsync(request.Policy);

                await _dbcontext.SaveChangesAsync();


                await transaction.CommitAsync();

                return "Insurance created successfully.";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("An error occurred while creating insurance.", ex);
            }
        }
        public async Task<List<Municipality>> GetAllMunicipalities()
        {
            return await _dbcontext.Municipalities.ToListAsync();
        }
        public async Task<List<PropertyType>> GetAllPropertyTypes()
        {

            var propertyTypes = await _dbcontext.PropertyTypes.ToListAsync();
            return (propertyTypes);
        }

        public async Task<List<Province>> GetAllProvinces()
        {
            return await _dbcontext.Provinces.ToListAsync();
        }
        public async Task<List<RiskType>> GetAllRiskTypes()
        {
            return await _dbcontext.RiskTypes.ToListAsync();
        }


        public async Task<List<PolicyOP>> GetPolicies(policyFilter filters)
        {
            return await _dbcontext.PolicyOP
                .FromSqlInterpolated($@"
            SELECT *
            FROM dbo.FGetPolicies(
                {filters.PolicyNumber},
                {filters.provinceId},
                {filters.districtId},
                {filters.municipalityId},
                {filters.propertyTypeId},
                {filters.riskTypeId},
                {filters.statusId},
                {filters.pageNumber},
                {filters.pageSize}
            )")
                .ToListAsync();
        }

    }
}
