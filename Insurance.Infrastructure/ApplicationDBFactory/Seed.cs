using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Entity.DbModel;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedProvinces(modelBuilder);
            SeedDistricts(modelBuilder);
            SeedMunicipalities(modelBuilder);
            SeedPropertyTypes(modelBuilder);
            SeedConstructionTypes(modelBuilder);
            SeedRiskTypes(modelBuilder);
            SeedPolicyStatuses(modelBuilder);
        }

        // ===========================
        // ROLES
        // ===========================
        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Agent" },
                new Role { RoleId = 3, RoleName = "Customer" }
            );
        }

        // ===========================
        // PROVINCES (7 Provinces of Nepal)
        // ===========================
        private static void SeedProvinces(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceId = 1, Name = "Koshi Province" },
                new Province { ProvinceId = 2, Name = "Madhesh Province" },
                new Province { ProvinceId = 3, Name = "Bagmati Province" },
                new Province { ProvinceId = 4, Name = "Gandaki Province" },
                new Province { ProvinceId = 5, Name = "Lumbini Province" },
                new Province { ProvinceId = 6, Name = "Karnali Province" },
                new Province { ProvinceId = 7, Name = "Sudurpashchim Province" }
            );
        }

        // ===========================
        // DISTRICTS (77 Districts of Nepal)
        // ===========================
        private static void SeedDistricts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>().HasData(
                // Province 1 - Koshi (14 districts)
                new District { DistrictId = 1, Name = "Taplejung", ProvinceId = 1 },
                new District { DistrictId = 2, Name = "Panchthar", ProvinceId = 1 },
                new District { DistrictId = 3, Name = "Ilam", ProvinceId = 1 },
                new District { DistrictId = 4, Name = "Jhapa", ProvinceId = 1 },
                new District { DistrictId = 5, Name = "Morang", ProvinceId = 1 },
                new District { DistrictId = 6, Name = "Sunsari", ProvinceId = 1 },
                new District { DistrictId = 7, Name = "Dhankuta", ProvinceId = 1 },
                new District { DistrictId = 8, Name = "Terhathum", ProvinceId = 1 },
                new District { DistrictId = 9, Name = "Sankhuwasabha", ProvinceId = 1 },
                new District { DistrictId = 10, Name = "Bhojpur", ProvinceId = 1 },
                new District { DistrictId = 11, Name = "Solukhumbu", ProvinceId = 1 },
                new District { DistrictId = 12, Name = "Okhaldhunga", ProvinceId = 1 },
                new District { DistrictId = 13, Name = "Khotang", ProvinceId = 1 },
                new District { DistrictId = 14, Name = "Udayapur", ProvinceId = 1 },

                // Province 2 - Madhesh (8 districts)
                new District { DistrictId = 15, Name = "Saptari", ProvinceId = 2 },
                new District { DistrictId = 16, Name = "Siraha", ProvinceId = 2 },
                new District { DistrictId = 17, Name = "Dhanusha", ProvinceId = 2 },
                new District { DistrictId = 18, Name = "Mahottari", ProvinceId = 2 },
                new District { DistrictId = 19, Name = "Sarlahi", ProvinceId = 2 },
                new District { DistrictId = 20, Name = "Rautahat", ProvinceId = 2 },
                new District { DistrictId = 21, Name = "Bara", ProvinceId = 2 },
                new District { DistrictId = 22, Name = "Parsa", ProvinceId = 2 },

                // Province 3 - Bagmati (13 districts)
                new District { DistrictId = 23, Name = "Dolakha", ProvinceId = 3 },
                new District { DistrictId = 24, Name = "Sindhupalchok", ProvinceId = 3 },
                new District { DistrictId = 25, Name = "Rasuwa", ProvinceId = 3 },
                new District { DistrictId = 26, Name = "Dhading", ProvinceId = 3 },
                new District { DistrictId = 27, Name = "Nuwakot", ProvinceId = 3 },
                new District { DistrictId = 28, Name = "Kathmandu", ProvinceId = 3 },
                new District { DistrictId = 29, Name = "Bhaktapur", ProvinceId = 3 },
                new District { DistrictId = 30, Name = "Lalitpur", ProvinceId = 3 },
                new District { DistrictId = 31, Name = "Kavrepalanchok", ProvinceId = 3 },
                new District { DistrictId = 32, Name = "Ramechhap", ProvinceId = 3 },
                new District { DistrictId = 33, Name = "Sindhuli", ProvinceId = 3 },
                new District { DistrictId = 34, Name = "Makwanpur", ProvinceId = 3 },
                new District { DistrictId = 35, Name = "Chitwan", ProvinceId = 3 },

                // Province 4 - Gandaki (11 districts)
                new District { DistrictId = 36, Name = "Gorkha", ProvinceId = 4 },
                new District { DistrictId = 37, Name = "Manang", ProvinceId = 4 },
                new District { DistrictId = 38, Name = "Mustang", ProvinceId = 4 },
                new District { DistrictId = 39, Name = "Myagdi", ProvinceId = 4 },
                new District { DistrictId = 40, Name = "Kaski", ProvinceId = 4 },
                new District { DistrictId = 41, Name = "Lamjung", ProvinceId = 4 },
                new District { DistrictId = 42, Name = "Tanahun", ProvinceId = 4 },
                new District { DistrictId = 43, Name = "Nawalpur", ProvinceId = 4 },
                new District { DistrictId = 44, Name = "Syangja", ProvinceId = 4 },
                new District { DistrictId = 45, Name = "Parbat", ProvinceId = 4 },
                new District { DistrictId = 46, Name = "Baglung", ProvinceId = 4 },

                // Province 5 - Lumbini (12 districts)
                new District { DistrictId = 47, Name = "Rukum East", ProvinceId = 5 },
                new District { DistrictId = 48, Name = "Rolpa", ProvinceId = 5 },
                new District { DistrictId = 49, Name = "Pyuthan", ProvinceId = 5 },
                new District { DistrictId = 50, Name = "Gulmi", ProvinceId = 5 },
                new District { DistrictId = 51, Name = "Arghakhanchi", ProvinceId = 5 },
                new District { DistrictId = 52, Name = "Palpa", ProvinceId = 5 },
                new District { DistrictId = 53, Name = "Nawalparasi East", ProvinceId = 5 },
                new District { DistrictId = 54, Name = "Rupandehi", ProvinceId = 5 },
                new District { DistrictId = 55, Name = "Kapilvastu", ProvinceId = 5 },
                new District { DistrictId = 56, Name = "Dang", ProvinceId = 5 },
                new District { DistrictId = 57, Name = "Banke", ProvinceId = 5 },
                new District { DistrictId = 58, Name = "Bardiya", ProvinceId = 5 },

                // Province 6 - Karnali (10 districts)
                new District { DistrictId = 59, Name = "Dolpa", ProvinceId = 6 },
                new District { DistrictId = 60, Name = "Mugu", ProvinceId = 6 },
                new District { DistrictId = 61, Name = "Humla", ProvinceId = 6 },
                new District { DistrictId = 62, Name = "Jumla", ProvinceId = 6 },
                new District { DistrictId = 63, Name = "Kalikot", ProvinceId = 6 },
                new District { DistrictId = 64, Name = "Dailekh", ProvinceId = 6 },
                new District { DistrictId = 65, Name = "Jajarkot", ProvinceId = 6 },
                new District { DistrictId = 66, Name = "Rukum West", ProvinceId = 6 },
                new District { DistrictId = 67, Name = "Salyan", ProvinceId = 6 },
                new District { DistrictId = 68, Name = "Surkhet", ProvinceId = 6 },

                // Province 7 - Sudurpashchim (9 districts)
                new District { DistrictId = 69, Name = "Bajura", ProvinceId = 7 },
                new District { DistrictId = 70, Name = "Bajhang", ProvinceId = 7 },
                new District { DistrictId = 71, Name = "Darchula", ProvinceId = 7 },
                new District { DistrictId = 72, Name = "Baitadi", ProvinceId = 7 },
                new District { DistrictId = 73, Name = "Dadeldhura", ProvinceId = 7 },
                new District { DistrictId = 74, Name = "Doti", ProvinceId = 7 },
                new District { DistrictId = 75, Name = "Achham", ProvinceId = 7 },
                new District { DistrictId = 76, Name = "Kailali", ProvinceId = 7 },
                new District { DistrictId = 77, Name = "Kanchanpur", ProvinceId = 7 }
            );
        }

        // ===========================
        // MUNICIPALITIES (key ones per district — expand as needed)
        // ===========================
        private static void SeedMunicipalities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Municipality>().HasData(
                // Kathmandu District (28)
                new Municipality { MunicipalityId = 1, Name = "Kathmandu Metropolitan City", DistrictId = 28 },
                new Municipality { MunicipalityId = 2, Name = "Kirtipur Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 3, Name = "Budhanilkantha Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 4, Name = "Kageshwari-Manohara Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 5, Name = "Tarakeshwar Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 6, Name = "Nagarjun Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 7, Name = "Shankharapur Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 8, Name = "Gokarneshwor Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 9, Name = "Dakshinkali Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 10, Name = "Chandragiri Municipality", DistrictId = 28 },
                new Municipality { MunicipalityId = 11, Name = "Tokha Municipality", DistrictId = 28 },

                // Lalitpur District (30)
                new Municipality { MunicipalityId = 12, Name = "Lalitpur Metropolitan City", DistrictId = 30 },
                new Municipality { MunicipalityId = 13, Name = "Mahalaxmi Municipality", DistrictId = 30 },
                new Municipality { MunicipalityId = 14, Name = "Godawari Municipality", DistrictId = 30 },
                new Municipality { MunicipalityId = 15, Name = "Bagmati Municipality", DistrictId = 30 },
                new Municipality { MunicipalityId = 16, Name = "Konjyosom Rural Municipality", DistrictId = 30 },

                // Bhaktapur District (29)
                new Municipality { MunicipalityId = 17, Name = "Bhaktapur Municipality", DistrictId = 29 },
                new Municipality { MunicipalityId = 18, Name = "Madhyapur Thimi Municipality", DistrictId = 29 },
                new Municipality { MunicipalityId = 19, Name = "Changunarayan Municipality", DistrictId = 29 },
                new Municipality { MunicipalityId = 20, Name = "Suryabinayak Municipality", DistrictId = 29 },

                // Chitwan District (35)
                new Municipality { MunicipalityId = 21, Name = "Bharatpur Metropolitan City", DistrictId = 35 },
                new Municipality { MunicipalityId = 22, Name = "Ratnanagar Municipality", DistrictId = 35 },
                new Municipality { MunicipalityId = 23, Name = "Madi Municipality", DistrictId = 35 },

                // Kaski District (40) - Pokhara
                new Municipality { MunicipalityId = 24, Name = "Pokhara Metropolitan City", DistrictId = 40 },
                new Municipality { MunicipalityId = 25, Name = "Annapurna Rural Municipality", DistrictId = 40 },
                new Municipality { MunicipalityId = 26, Name = "Machhapuchchhre Rural Municipality", DistrictId = 40 },
                new Municipality { MunicipalityId = 27, Name = "Madi Rural Municipality", DistrictId = 40 },
                new Municipality { MunicipalityId = 28, Name = "Rupa Rural Municipality", DistrictId = 40 },

                // Jhapa District (4)
                new Municipality { MunicipalityId = 29, Name = "Bhadrapur Municipality", DistrictId = 4 },
                new Municipality { MunicipalityId = 30, Name = "Mechinagar Municipality", DistrictId = 4 },
                new Municipality { MunicipalityId = 31, Name = "Birtamod Municipality", DistrictId = 4 },
                new Municipality { MunicipalityId = 32, Name = "Damak Municipality", DistrictId = 4 },
                new Municipality { MunicipalityId = 33, Name = "Kankai Municipality", DistrictId = 4 },

                // Morang District (5)
                new Municipality { MunicipalityId = 34, Name = "Biratnagar Metropolitan City", DistrictId = 5 },
                new Municipality { MunicipalityId = 35, Name = "Rangeli Municipality", DistrictId = 5 },
                new Municipality { MunicipalityId = 36, Name = "Sundar Haraicha Municipality", DistrictId = 5 },
                new Municipality { MunicipalityId = 37, Name = "Letang Municipality", DistrictId = 5 },

                // Sunsari District (6)
                new Municipality { MunicipalityId = 38, Name = "Dharan Sub-Metropolitan City", DistrictId = 6 },
                new Municipality { MunicipalityId = 39, Name = "Inaruwa Municipality", DistrictId = 6 },
                new Municipality { MunicipalityId = 40, Name = "Itahari Sub-Metropolitan City", DistrictId = 6 },
                new Municipality { MunicipalityId = 41, Name = "Duhabi Municipality", DistrictId = 6 },

                // Rupandehi District (54)
                new Municipality { MunicipalityId = 42, Name = "Butwal Sub-Metropolitan City", DistrictId = 54 },
                new Municipality { MunicipalityId = 43, Name = "Lumbini Sanskritik Municipality", DistrictId = 54 },
                new Municipality { MunicipalityId = 44, Name = "Devdaha Municipality", DistrictId = 54 },
                new Municipality { MunicipalityId = 45, Name = "Sainamaina Municipality", DistrictId = 54 },
                new Municipality { MunicipalityId = 46, Name = "Tilottama Municipality", DistrictId = 54 },

                // Banke District (57)
                new Municipality { MunicipalityId = 47, Name = "Nepalgunj Sub-Metropolitan City", DistrictId = 57 },
                new Municipality { MunicipalityId = 48, Name = "Kohalpur Municipality", DistrictId = 57 },
                new Municipality { MunicipalityId = 49, Name = "Rapti Sonari Municipality", DistrictId = 57 },

                // Surkhet District (68)
                new Municipality { MunicipalityId = 50, Name = "Birendranagar Municipality", DistrictId = 68 },
                new Municipality { MunicipalityId = 51, Name = "Gurtu Rural Municipality", DistrictId = 68 },

                // Kailali District (76)
                new Municipality { MunicipalityId = 52, Name = "Dhangadhi Sub-Metropolitan City", DistrictId = 76 },
                new Municipality { MunicipalityId = 53, Name = "Ghodaghodi Municipality", DistrictId = 76 },
                new Municipality { MunicipalityId = 54, Name = "Tikapur Municipality", DistrictId = 76 },
                new Municipality { MunicipalityId = 55, Name = "Bhajani Municipality", DistrictId = 76 },

                // Kanchanpur District (77)
                new Municipality { MunicipalityId = 56, Name = "Mahendranagar Municipality", DistrictId = 77 },
                new Municipality { MunicipalityId = 57, Name = "Bedkot Municipality", DistrictId = 77 },
                new Municipality { MunicipalityId = 58, Name = "Punarbas Municipality", DistrictId = 77 },

                // Dhanusha District (17)
                new Municipality { MunicipalityId = 59, Name = "Janakpur Sub-Metropolitan City", DistrictId = 17 },
                new Municipality { MunicipalityId = 60, Name = "Dhanusadham Municipality", DistrictId = 17 },

                // Bara District (21)
                new Municipality { MunicipalityId = 61, Name = "Kalaiya Sub-Metropolitan City", DistrictId = 21 },
                new Municipality { MunicipalityId = 62, Name = "Jitpur Simara Sub-Metropolitan City", DistrictId = 21 },
                new Municipality { MunicipalityId = 63, Name = "Mahagadhimai Municipality", DistrictId = 21 },

                // Parsa District (22)
                new Municipality { MunicipalityId = 64, Name = "Birgunj Metropolitan City", DistrictId = 22 },
                new Municipality { MunicipalityId = 65, Name = "Bahudarmai Municipality", DistrictId = 22 },
                new Municipality { MunicipalityId = 66, Name = "Pkr Municipality", DistrictId = 22 }
            );
        }

        // ===========================
        // PROPERTY TYPES
        // ===========================
        private static void SeedPropertyTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { PropertyTypeId = 1, Name = "Residential" },
                new PropertyType { PropertyTypeId = 2, Name = "Commercial" },
                new PropertyType { PropertyTypeId = 3, Name = "Industrial" },
                new PropertyType { PropertyTypeId = 4, Name = "Agricultural" },
                new PropertyType { PropertyTypeId = 5, Name = "Mixed Use" }
            );
        }

        // ===========================
        // CONSTRUCTION TYPES
        // ===========================
        private static void SeedConstructionTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConstructionType>().HasData(
                new ConstructionType { ConstructionTypeId = 1, Name = "RCC (Reinforced Cement Concrete)" },
                new ConstructionType { ConstructionTypeId = 2, Name = "Brick & Cement" },
                new ConstructionType { ConstructionTypeId = 3, Name = "Stone & Mud" },
                new ConstructionType { ConstructionTypeId = 4, Name = "Wooden Frame" },
                new ConstructionType { ConstructionTypeId = 5, Name = "Steel Frame" },
                new ConstructionType { ConstructionTypeId = 6, Name = "Bamboo/Thatch" }
            );
        }

        // ===========================
        // RISK TYPES
        // ===========================
        private static void SeedRiskTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RiskType>().HasData(
                new RiskType { RiskTypeId = 1, Name = "Fire & Allied Perils" },
                new RiskType { RiskTypeId = 2, Name = "Earthquake" },
                new RiskType { RiskTypeId = 3, Name = "Flood & Inundation" },
                new RiskType { RiskTypeId = 4, Name = "Landslide" },
                new RiskType { RiskTypeId = 5, Name = "Theft & Burglary" },
                new RiskType { RiskTypeId = 6, Name = "Natural Disaster (Comprehensive)" },
                new RiskType { RiskTypeId = 7, Name = "Storm & Tempest" },
                new RiskType { RiskTypeId = 8, Name = "Impact Damage" },
                new RiskType { RiskTypeId = 9, Name = "Riot & Strike" },
                new RiskType { RiskTypeId = 10, Name = "All Risk" }
            );
        }

        // ===========================
        // POLICY STATUSES
        // ===========================
        private static void SeedPolicyStatuses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyStatus>().HasData(
                new PolicyStatus { PolicyStatusId = 1, Name = "Draft" },
                new PolicyStatus { PolicyStatusId = 2, Name = "Active" },
                new PolicyStatus { PolicyStatusId = 3, Name = "Expired" },
                new PolicyStatus { PolicyStatusId = 4, Name = "Cancelled" },
                new PolicyStatus { PolicyStatusId = 5, Name = "Pending Renewal" },
                new PolicyStatus { PolicyStatusId = 6, Name = "Claimed" },
                new PolicyStatus { PolicyStatusId = 7, Name = "Suspended" }
            );
        }
    }
}


