using Microsoft.EntityFrameworkCore.Migrations;

namespace RevitRibbon.Infrastructure.Migrations
{
    public partial class UpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScriptId",
                table: "Parameter");

            migrationBuilder.AlterColumn<string>(
                name: "Tooltip",
                table: "Script",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Script",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScriptId",
                table: "RevitParam",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Group",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RevitParam_ScriptId",
                table: "RevitParam",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_GroupId",
                table: "Parameter",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_RevitParamId",
                table: "Parameter",
                column: "RevitParamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameter_Group_GroupId",
                table: "Parameter",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameter_RevitParam_RevitParamId",
                table: "Parameter",
                column: "RevitParamId",
                principalTable: "RevitParam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RevitParam_Script_ScriptId",
                table: "RevitParam",
                column: "ScriptId",
                principalTable: "Script",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameter_Group_GroupId",
                table: "Parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameter_RevitParam_RevitParamId",
                table: "Parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_RevitParam_Script_ScriptId",
                table: "RevitParam");

            migrationBuilder.DropIndex(
                name: "IX_RevitParam_ScriptId",
                table: "RevitParam");

            migrationBuilder.DropIndex(
                name: "IX_Parameter_GroupId",
                table: "Parameter");

            migrationBuilder.DropIndex(
                name: "IX_Parameter_RevitParamId",
                table: "Parameter");

            migrationBuilder.DropColumn(
                name: "ScriptId",
                table: "RevitParam");

            migrationBuilder.AlterColumn<string>(
                name: "Tooltip",
                table: "Script",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Script",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ScriptId",
                table: "Parameter",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Group",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
