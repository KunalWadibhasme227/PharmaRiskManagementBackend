using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuditfindingReplation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Finding_AuditId",
                table: "Finding",
                column: "AuditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finding_Audit_AuditId",
                table: "Finding",
                column: "AuditId",
                principalTable: "Audit",
                principalColumn: "AuditId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finding_Audit_AuditId",
                table: "Finding");

            migrationBuilder.DropIndex(
                name: "IX_Finding_AuditId",
                table: "Finding");
        }
    }
}
