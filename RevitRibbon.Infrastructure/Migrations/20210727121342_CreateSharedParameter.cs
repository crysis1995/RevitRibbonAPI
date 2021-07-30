using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RevitRibbon.Infrastructure.Migrations
{
    public partial class CreateSharedParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_RevitParams_RevitParamId",
                table: "Parameters");

            migrationBuilder.DropTable(
                name: "RevitParams");

            migrationBuilder.DropIndex(
                name: "IX_Parameters_RevitParamId",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "RevitParamId",
                table: "Parameters");

            migrationBuilder.AlterColumn<string>(
                name: "Tooltip",
                table: "Scripts",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<Guid>(
                name: "SharedParameterId",
                table: "Parameters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SharedParameterGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedParameterGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SharedParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ScriptId = table.Column<int>(type: "integer", nullable: false),
                    SharedParameterGroupId = table.Column<int>(type: "integer", nullable: false),
                    TextInputType = table.Column<int>(type: "integer", nullable: false),
                    ParameterType = table.Column<int>(type: "integer", nullable: false),
                    BuiltInParameterGroup = table.Column<int>(type: "integer", nullable: false),
                    BuiltInCategories = table.Column<int[]>(type: "integer[]", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedParameters_Scripts_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedParameters_SharedParameterGroups_SharedParameterGroup~",
                        column: x => x.SharedParameterGroupId,
                        principalTable: "SharedParameterGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Name",
                table: "Scripts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_SharedParameterId",
                table: "Parameters",
                column: "SharedParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SharedParameterGroups_Name",
                table: "SharedParameterGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SharedParameters_Name",
                table: "SharedParameters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SharedParameters_ScriptId",
                table: "SharedParameters",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedParameters_SharedParameterGroupId",
                table: "SharedParameters",
                column: "SharedParameterGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_SharedParameters_SharedParameterId",
                table: "Parameters",
                column: "SharedParameterId",
                principalTable: "SharedParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_SharedParameters_SharedParameterId",
                table: "Parameters");

            migrationBuilder.DropTable(
                name: "SharedParameters");

            migrationBuilder.DropTable(
                name: "SharedParameterGroups");

            migrationBuilder.DropIndex(
                name: "IX_Scripts_Name",
                table: "Scripts");

            migrationBuilder.DropIndex(
                name: "IX_Parameters_SharedParameterId",
                table: "Parameters");

            migrationBuilder.DropIndex(
                name: "IX_Groups_Name",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SharedParameterId",
                table: "Parameters");

            migrationBuilder.AlterColumn<string>(
                name: "Tooltip",
                table: "Scripts",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RevitParamId",
                table: "Parameters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RevitParams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ParamType = table.Column<int>(type: "integer", nullable: false),
                    ScriptId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevitParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevitParams_Scripts_ScriptId",
                        column: x => x.ScriptId,
                        principalTable: "Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_RevitParamId",
                table: "Parameters",
                column: "RevitParamId");

            migrationBuilder.CreateIndex(
                name: "IX_RevitParams_ScriptId",
                table: "RevitParams",
                column: "ScriptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_RevitParams_RevitParamId",
                table: "Parameters",
                column: "RevitParamId",
                principalTable: "RevitParams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
