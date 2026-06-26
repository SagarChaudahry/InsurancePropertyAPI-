using System;
using System.Xml.Linq;

namespace Insurance.Domain.Entity.DbModel
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }
        public int? RoleId { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public int? Status { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public int? Status { get; set; }
    }

    public class RefreshToken
    {
        public int Rfid { get; set; }
        public int? UserId { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiry { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Status { get; set; }
    }

    public class Province
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class District
    {
        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Municipality
    {
        public int MunicipalityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class PropertyType
    {
        public int PropertyTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class ConstructionType
    {
        public int ConstructionTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Property
    {
        public int PropertyId { get; set; }

        //public int InsuredId { get; set; }
        public int PropertyTypeId { get; set; }
        public int ConstructionTypeId { get; set; }
        public short YearBuilt { get; set; }
        public byte NumberOfFloors { get; set; }
        public string AddressLine { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int MunicipalityId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class InsuredPerson
    {
        public int InsuredId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string CitizenshipOrIdNo { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    //public class PolicyOP
    //{
    //    public string policynumber { get; set; }
    //    public string InsuredName { get; set; }
    //    public string propertytype { get; set; }
    //    public string provincedistrict { get; set; }
    //    public decimal PremiumAmount { get; set; }
    //    public string status { get; set; }
    //}

    public class PolicyOP
    {
        public string PolicyNumber { get; set; }
        public string InsuredName { get; set; }
        public string PropertyType { get; set; }
        public string ProvinceDistrict { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string RiskType { get; set; }
        public decimal PremiumAmount { get; set; }
        public string Status { get; set; }
    }

    public class RiskType
    {
        public int RiskTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class PolicyStatus
    {
        public int PolicyStatusId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public int InsuredId { get; set; }
        public int PropertyId { get; set; }
        public int RiskTypeId { get; set; }
        public int PolicyStatusId { get; set; }
        public decimal SumInsured { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateOnly PolicyStartDate { get; set; }
        public DateOnly PolicyEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class policyFilter
    {
        public string? PolicyNumber { get; set; }
        public int? provinceId { get; set; }
        public int? districtId { get; set; }
        public int? municipalityId { get; set; }
        public int? propertyTypeId { get; set; }
        public int? riskTypeId { get; set; }
        public int? statusId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        
    }



}