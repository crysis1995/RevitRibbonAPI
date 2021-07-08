using Microsoft.EntityFrameworkCore.Migrations;

namespace RevitRibbon.Infrastructure.Migrations
{
    public partial class UpdateRevitSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Parameter");

            migrationBuilder.DropColumn(
                name: "RevitName",
                table: "Parameter");

            migrationBuilder.RenameColumn(
                name: "ParamType",
                table: "Parameter",
                newName: "RevitParamId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Parameter",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(char[]),
                oldType: "character(1)[]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RevitParamId",
                table: "Parameter",
                newName: "ParamType");

            migrationBuilder.AlterColumn<char[]>(
                name: "Code",
                table: "Parameter",
                type: "character(1)[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Parameter",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RevitName",
                table: "Parameter",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
