using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_Software.Data.projmigrations
{
    public partial class Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareRequirement_Project_ProjectId",
                table: "SoftwareRequirement");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Client",
                newName: "Email");

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
                name: "Endereco",
                table: "Client",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Client",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Client",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareRequirement_Project_ProjectId",
                table: "SoftwareRequirement");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Client",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "SoftwareRequirement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareRequirement_Project_ProjectId",
                table: "SoftwareRequirement",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
