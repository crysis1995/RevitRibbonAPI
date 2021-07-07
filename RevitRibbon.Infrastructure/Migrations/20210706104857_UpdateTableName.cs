using Microsoft.EntityFrameworkCore.Migrations;

namespace RevitRibbon.Infrastructure.Migrations
{
    public partial class UpdateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Script",
                table: "Script");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RevitParam",
                table: "RevitParam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameter",
                table: "Parameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Script",
                newName: "Scripts");

            migrationBuilder.RenameTable(
                name: "RevitParam",
                newName: "RevitParams");

            migrationBuilder.RenameTable(
                name: "Parameter",
                newName: "Parameters");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_RevitParam_ScriptId",
                table: "RevitParams",
                newName: "IX_RevitParams_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameter_RevitParamId",
                table: "Parameters",
                newName: "IX_Parameters_RevitParamId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameter_GroupId",
                table: "Parameters",
                newName: "IX_Parameters_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts",
                table: "Scripts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RevitParams",
                table: "RevitParams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Groups_GroupId",
                table: "Parameters",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_RevitParams_RevitParamId",
                table: "Parameters",
                column: "RevitParamId",
                principalTable: "RevitParams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RevitParams_Scripts_ScriptId",
                table: "RevitParams",
                column: "ScriptId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Groups_GroupId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_RevitParams_RevitParamId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_RevitParams_Scripts_ScriptId",
                table: "RevitParams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts",
                table: "Scripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RevitParams",
                table: "RevitParams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Scripts",
                newName: "Script");

            migrationBuilder.RenameTable(
                name: "RevitParams",
                newName: "RevitParam");

            migrationBuilder.RenameTable(
                name: "Parameters",
                newName: "Parameter");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_RevitParams_ScriptId",
                table: "RevitParam",
                newName: "IX_RevitParam_ScriptId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_RevitParamId",
                table: "Parameter",
                newName: "IX_Parameter_RevitParamId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_GroupId",
                table: "Parameter",
                newName: "IX_Parameter_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Script",
                table: "Script",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RevitParam",
                table: "RevitParam",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameter",
                table: "Parameter",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

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
    }
}
