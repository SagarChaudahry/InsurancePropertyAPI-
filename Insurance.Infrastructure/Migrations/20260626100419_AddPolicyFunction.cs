using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Insurance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPolicyFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstructionTypes",
                columns: table => new
                {
                    ConstructionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionTypes", x => x.ConstructionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InsuredPersons",
                columns: table => new
                {
                    InsuredId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenshipOrIdNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuredPersons", x => x.InsuredId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyOP",
                columns: table => new
                {
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuredName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PremiumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PolicyStatuses",
                columns: table => new
                {
                    PolicyStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyStatuses", x => x.PolicyStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.PropertyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "RiskTypes",
                columns: table => new
                {
                    RiskTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskTypes", x => x.RiskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.MunicipalityId);
                    table.ForeignKey(
                        name: "FK_Municipalities_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Rfid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Rfid);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    ConstructionTypeId = table.Column<int>(type: "int", nullable: false),
                    YearBuilt = table.Column<short>(type: "smallint", nullable: false),
                    NumberOfFloors = table.Column<byte>(type: "tinyint", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_ConstructionTypes_ConstructionTypeId",
                        column: x => x.ConstructionTypeId,
                        principalTable: "ConstructionTypes",
                        principalColumn: "ConstructionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "PropertyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuredId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    RiskTypeId = table.Column<int>(type: "int", nullable: false),
                    PolicyStatusId = table.Column<int>(type: "int", nullable: false),
                    SumInsured = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PolicyStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PolicyEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_Policies_InsuredPersons_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "InsuredPersons",
                        principalColumn: "InsuredId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_PolicyStatuses_PolicyStatusId",
                        column: x => x.PolicyStatusId,
                        principalTable: "PolicyStatuses",
                        principalColumn: "PolicyStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_RiskTypes_RiskTypeId",
                        column: x => x.RiskTypeId,
                        principalTable: "RiskTypes",
                        principalColumn: "RiskTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConstructionTypes",
                columns: new[] { "ConstructionTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "RCC (Reinforced Cement Concrete)" },
                    { 2, "Brick & Cement" },
                    { 3, "Stone & Mud" },
                    { 4, "Wooden Frame" },
                    { 5, "Steel Frame" },
                    { 6, "Bamboo/Thatch" }
                });

            migrationBuilder.InsertData(
                table: "PolicyStatuses",
                columns: new[] { "PolicyStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Draft" },
                    { 2, "Active" },
                    { 3, "Expired" },
                    { 4, "Cancelled" },
                    { 5, "Pending Renewal" },
                    { 6, "Claimed" },
                    { 7, "Suspended" }
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "PropertyTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Residential" },
                    { 2, "Commercial" },
                    { 3, "Industrial" },
                    { 4, "Agricultural" },
                    { 5, "Mixed Use" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "Name" },
                values: new object[,]
                {
                    { 1, "Koshi Province" },
                    { 2, "Madhesh Province" },
                    { 3, "Bagmati Province" },
                    { 4, "Gandaki Province" },
                    { 5, "Lumbini Province" },
                    { 6, "Karnali Province" },
                    { 7, "Sudurpashchim Province" }
                });

            migrationBuilder.InsertData(
                table: "RiskTypes",
                columns: new[] { "RiskTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Fire & Allied Perils" },
                    { 2, "Earthquake" },
                    { 3, "Flood & Inundation" },
                    { 4, "Landslide" },
                    { 5, "Theft & Burglary" },
                    { 6, "Natural Disaster (Comprehensive)" },
                    { 7, "Storm & Tempest" },
                    { 8, "Impact Damage" },
                    { 9, "Riot & Strike" },
                    { 10, "All Risk" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { 1, "Admin", null },
                    { 2, "Agent", null },
                    { 3, "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "DistrictId", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Taplejung", 1 },
                    { 2, "Panchthar", 1 },
                    { 3, "Ilam", 1 },
                    { 4, "Jhapa", 1 },
                    { 5, "Morang", 1 },
                    { 6, "Sunsari", 1 },
                    { 7, "Dhankuta", 1 },
                    { 8, "Terhathum", 1 },
                    { 9, "Sankhuwasabha", 1 },
                    { 10, "Bhojpur", 1 },
                    { 11, "Solukhumbu", 1 },
                    { 12, "Okhaldhunga", 1 },
                    { 13, "Khotang", 1 },
                    { 14, "Udayapur", 1 },
                    { 15, "Saptari", 2 },
                    { 16, "Siraha", 2 },
                    { 17, "Dhanusha", 2 },
                    { 18, "Mahottari", 2 },
                    { 19, "Sarlahi", 2 },
                    { 20, "Rautahat", 2 },
                    { 21, "Bara", 2 },
                    { 22, "Parsa", 2 },
                    { 23, "Dolakha", 3 },
                    { 24, "Sindhupalchok", 3 },
                    { 25, "Rasuwa", 3 },
                    { 26, "Dhading", 3 },
                    { 27, "Nuwakot", 3 },
                    { 28, "Kathmandu", 3 },
                    { 29, "Bhaktapur", 3 },
                    { 30, "Lalitpur", 3 },
                    { 31, "Kavrepalanchok", 3 },
                    { 32, "Ramechhap", 3 },
                    { 33, "Sindhuli", 3 },
                    { 34, "Makwanpur", 3 },
                    { 35, "Chitwan", 3 },
                    { 36, "Gorkha", 4 },
                    { 37, "Manang", 4 },
                    { 38, "Mustang", 4 },
                    { 39, "Myagdi", 4 },
                    { 40, "Kaski", 4 },
                    { 41, "Lamjung", 4 },
                    { 42, "Tanahun", 4 },
                    { 43, "Nawalpur", 4 },
                    { 44, "Syangja", 4 },
                    { 45, "Parbat", 4 },
                    { 46, "Baglung", 4 },
                    { 47, "Rukum East", 5 },
                    { 48, "Rolpa", 5 },
                    { 49, "Pyuthan", 5 },
                    { 50, "Gulmi", 5 },
                    { 51, "Arghakhanchi", 5 },
                    { 52, "Palpa", 5 },
                    { 53, "Nawalparasi East", 5 },
                    { 54, "Rupandehi", 5 },
                    { 55, "Kapilvastu", 5 },
                    { 56, "Dang", 5 },
                    { 57, "Banke", 5 },
                    { 58, "Bardiya", 5 },
                    { 59, "Dolpa", 6 },
                    { 60, "Mugu", 6 },
                    { 61, "Humla", 6 },
                    { 62, "Jumla", 6 },
                    { 63, "Kalikot", 6 },
                    { 64, "Dailekh", 6 },
                    { 65, "Jajarkot", 6 },
                    { 66, "Rukum West", 6 },
                    { 67, "Salyan", 6 },
                    { 68, "Surkhet", 6 },
                    { 69, "Bajura", 7 },
                    { 70, "Bajhang", 7 },
                    { 71, "Darchula", 7 },
                    { 72, "Baitadi", 7 },
                    { 73, "Dadeldhura", 7 },
                    { 74, "Doti", 7 },
                    { 75, "Achham", 7 },
                    { 76, "Kailali", 7 },
                    { 77, "Kanchanpur", 7 }
                });

            migrationBuilder.InsertData(
                table: "Municipalities",
                columns: new[] { "MunicipalityId", "DistrictId", "Name" },
                values: new object[,]
                {
                    { 1, 28, "Kathmandu Metropolitan City" },
                    { 2, 28, "Kirtipur Municipality" },
                    { 3, 28, "Budhanilkantha Municipality" },
                    { 4, 28, "Kageshwari-Manohara Municipality" },
                    { 5, 28, "Tarakeshwar Municipality" },
                    { 6, 28, "Nagarjun Municipality" },
                    { 7, 28, "Shankharapur Municipality" },
                    { 8, 28, "Gokarneshwor Municipality" },
                    { 9, 28, "Dakshinkali Municipality" },
                    { 10, 28, "Chandragiri Municipality" },
                    { 11, 28, "Tokha Municipality" },
                    { 12, 30, "Lalitpur Metropolitan City" },
                    { 13, 30, "Mahalaxmi Municipality" },
                    { 14, 30, "Godawari Municipality" },
                    { 15, 30, "Bagmati Municipality" },
                    { 16, 30, "Konjyosom Rural Municipality" },
                    { 17, 29, "Bhaktapur Municipality" },
                    { 18, 29, "Madhyapur Thimi Municipality" },
                    { 19, 29, "Changunarayan Municipality" },
                    { 20, 29, "Suryabinayak Municipality" },
                    { 21, 35, "Bharatpur Metropolitan City" },
                    { 22, 35, "Ratnanagar Municipality" },
                    { 23, 35, "Madi Municipality" },
                    { 24, 40, "Pokhara Metropolitan City" },
                    { 25, 40, "Annapurna Rural Municipality" },
                    { 26, 40, "Machhapuchchhre Rural Municipality" },
                    { 27, 40, "Madi Rural Municipality" },
                    { 28, 40, "Rupa Rural Municipality" },
                    { 29, 4, "Bhadrapur Municipality" },
                    { 30, 4, "Mechinagar Municipality" },
                    { 31, 4, "Birtamod Municipality" },
                    { 32, 4, "Damak Municipality" },
                    { 33, 4, "Kankai Municipality" },
                    { 34, 5, "Biratnagar Metropolitan City" },
                    { 35, 5, "Rangeli Municipality" },
                    { 36, 5, "Sundar Haraicha Municipality" },
                    { 37, 5, "Letang Municipality" },
                    { 38, 6, "Dharan Sub-Metropolitan City" },
                    { 39, 6, "Inaruwa Municipality" },
                    { 40, 6, "Itahari Sub-Metropolitan City" },
                    { 41, 6, "Duhabi Municipality" },
                    { 42, 54, "Butwal Sub-Metropolitan City" },
                    { 43, 54, "Lumbini Sanskritik Municipality" },
                    { 44, 54, "Devdaha Municipality" },
                    { 45, 54, "Sainamaina Municipality" },
                    { 46, 54, "Tilottama Municipality" },
                    { 47, 57, "Nepalgunj Sub-Metropolitan City" },
                    { 48, 57, "Kohalpur Municipality" },
                    { 49, 57, "Rapti Sonari Municipality" },
                    { 50, 68, "Birendranagar Municipality" },
                    { 51, 68, "Gurtu Rural Municipality" },
                    { 52, 76, "Dhangadhi Sub-Metropolitan City" },
                    { 53, 76, "Ghodaghodi Municipality" },
                    { 54, 76, "Tikapur Municipality" },
                    { 55, 76, "Bhajani Municipality" },
                    { 56, 77, "Mahendranagar Municipality" },
                    { 57, 77, "Bedkot Municipality" },
                    { 58, 77, "Punarbas Municipality" },
                    { 59, 17, "Janakpur Sub-Metropolitan City" },
                    { 60, 17, "Dhanusadham Municipality" },
                    { 61, 21, "Kalaiya Sub-Metropolitan City" },
                    { 62, 21, "Jitpur Simara Sub-Metropolitan City" },
                    { 63, 21, "Mahagadhimai Municipality" },
                    { 64, 22, "Birgunj Metropolitan City" },
                    { 65, 22, "Bahudarmai Municipality" },
                    { 66, 22, "Pkr Municipality" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_DistrictId",
                table: "Municipalities",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_InsuredId",
                table: "Policies",
                column: "InsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PolicyStatusId",
                table: "Policies",
                column: "PolicyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PropertyId",
                table: "Policies",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_RiskTypeId",
                table: "Policies",
                column: "RiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ConstructionTypeId",
                table: "Properties",
                column: "ConstructionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_DistrictId",
                table: "Properties",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_MunicipalityId",
                table: "Properties",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ProvinceId",
                table: "Properties",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "PolicyOP");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "InsuredPersons");

            migrationBuilder.DropTable(
                name: "PolicyStatuses");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "RiskTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ConstructionTypes");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
