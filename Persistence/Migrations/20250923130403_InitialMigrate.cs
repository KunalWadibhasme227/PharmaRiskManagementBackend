using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    AuditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    AuditType = table.Column<int>(type: "int", nullable: false),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeadAuditor = table.Column<int>(type: "int", maxLength: 200, nullable: true),
                    Score = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Auditor",
                columns: table => new
                {
                    AuditorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditor", x => x.AuditorId);
                });

            migrationBuilder.CreateTable(
                name: "AuditTypeMaster",
                columns: table => new
                {
                    AuditTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTypeMaster", x => x.AuditTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MasterGlobalCodeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterGlobalCodeTypeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlobalCodesKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GlobalCodesName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterGlobalCodeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterGlobalCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterGlobalCodeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterGlobalCodeTypeId = table.Column<int>(type: "int", nullable: false),
                    GlobalCodesKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GlobalCodesName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GlobalCodesValue = table.Column<int>(type: "int", nullable: true),
                    GlobalCodesDisplayOrder = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterGlobalCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterGlobalCode_MasterGlobalCodeType_MasterGlobalCodeTypeId",
                        column: x => x.MasterGlobalCodeTypeId,
                        principalTable: "MasterGlobalCodeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterGlobalCode_MasterGlobalCodeTypeId",
                table: "MasterGlobalCode",
                column: "MasterGlobalCodeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "Auditor");

            migrationBuilder.DropTable(
                name: "AuditTypeMaster");

            migrationBuilder.DropTable(
                name: "MasterGlobalCode");

            migrationBuilder.DropTable(
                name: "MasterGlobalCodeType");
        }
    }
}
