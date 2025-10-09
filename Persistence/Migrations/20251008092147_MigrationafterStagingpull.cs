using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationafterStagingpull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CategoryDocumentsId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusCodeId = table.Column<int>(type: "int", nullable: true),
                    ComplianceScore = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VersionNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReviewDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLatestVersion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Document_MasterGlobalCode_CategoryDocumentsId",
                        column: x => x.CategoryDocumentsId,
                        principalTable: "MasterGlobalCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_MasterGlobalCode_StatusCodeId",
                        column: x => x.StatusCodeId,
                        principalTable: "MasterGlobalCode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MasterGlobalDocuments",
                columns: table => new
                {
                    GlobalDocumentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentsType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentsValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterGlobalDocuments", x => x.GlobalDocumentsId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentActionLog",
                columns: table => new
                {
                    ActionLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeCodeId = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentActionLog", x => x.ActionLogId);
                    table.ForeignKey(
                        name: "FK_DocumentActionLog_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_DocumentActionLog_MasterGlobalCode_ActionTypeCodeId",
                        column: x => x.ActionTypeCodeId,
                        principalTable: "MasterGlobalCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentWorkflow",
                columns: table => new
                {
                    WorkflowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    StageCodeId = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DocCount = table.Column<int>(type: "int", nullable: false),
                    AvgProcessingTime = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentWorkflow", x => x.WorkflowId);
                    table.ForeignKey(
                        name: "FK_DocumentWorkflow_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentWorkflow_MasterGlobalCode_StageCodeId",
                        column: x => x.StageCodeId,
                        principalTable: "MasterGlobalCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_CategoryDocumentsId",
                table: "Document",
                column: "CategoryDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_StatusCodeId",
                table: "Document",
                column: "StatusCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentActionLog_ActionTypeCodeId",
                table: "DocumentActionLog",
                column: "ActionTypeCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentActionLog_DocumentId",
                table: "DocumentActionLog",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWorkflow_DocumentId",
                table: "DocumentWorkflow",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWorkflow_StageCodeId",
                table: "DocumentWorkflow",
                column: "StageCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterGlobalDocuments_DocumentsType_DocumentsValue",
                table: "MasterGlobalDocuments",
                columns: new[] { "DocumentsType", "DocumentsValue" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentActionLog");

            migrationBuilder.DropTable(
                name: "DocumentWorkflow");

            migrationBuilder.DropTable(
                name: "MasterGlobalDocuments");

            migrationBuilder.DropTable(
                name: "Document");
        }
    }
}
