using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_Software.Migrations
{
    public partial class Clients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareRequirement_Project_ProjectId",
                table: "SoftwareRequirement");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "SoftwareRequirement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareRequirement_Project_ProjectId",
                table: "SoftwareRequirement",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareRequirement_Project_ProjectId",
                table: "SoftwareRequirement");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "SoftwareRequirement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareRequirement_Project_ProjectId",
                table: "SoftwareRequirement",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
