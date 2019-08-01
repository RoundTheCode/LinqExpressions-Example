using Microsoft.EntityFrameworkCore.Migrations;

namespace RoundTheCode.LinqExpressions_Example.Data.Migrations
{
    public partial class ChangeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmTimeEntities_FilmEntities_FilmId",
                table: "FilmTimeEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmTimeEntities",
                table: "FilmTimeEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmEntities",
                table: "FilmEntities");

            migrationBuilder.RenameTable(
                name: "FilmTimeEntities",
                newName: "FilmTime");

            migrationBuilder.RenameTable(
                name: "FilmEntities",
                newName: "Film");

            migrationBuilder.RenameIndex(
                name: "IX_FilmTimeEntities_FilmId",
                table: "FilmTime",
                newName: "IX_FilmTime_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmTime",
                table: "FilmTime",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Film",
                table: "Film",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmTime_Film_FilmId",
                table: "FilmTime",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmTime_Film_FilmId",
                table: "FilmTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmTime",
                table: "FilmTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Film",
                table: "Film");

            migrationBuilder.RenameTable(
                name: "FilmTime",
                newName: "FilmTimeEntities");

            migrationBuilder.RenameTable(
                name: "Film",
                newName: "FilmEntities");

            migrationBuilder.RenameIndex(
                name: "IX_FilmTime_FilmId",
                table: "FilmTimeEntities",
                newName: "IX_FilmTimeEntities_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmTimeEntities",
                table: "FilmTimeEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmEntities",
                table: "FilmEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmTimeEntities_FilmEntities_FilmId",
                table: "FilmTimeEntities",
                column: "FilmId",
                principalTable: "FilmEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
