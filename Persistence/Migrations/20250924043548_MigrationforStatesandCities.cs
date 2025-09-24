using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationforStatesandCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATE_CODE = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    STATE_NAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_STATE = table.Column<int>(type: "int", nullable: false),
                    CITY = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    COUNTY = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LATITUDE = table.Column<double>(type: "float", nullable: false),
                    LONGITUDE = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_States_ID_STATE",
                        column: x => x.ID_STATE,
                        principalTable: "States",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ID_STATE",
                table: "Cities",
                column: "ID_STATE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
