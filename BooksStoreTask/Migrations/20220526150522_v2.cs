using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksStoreTask.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_tables_authorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_tables_Nationalities_nationalityId",
                table: "tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tables",
                table: "tables");

            migrationBuilder.RenameTable(
                name: "tables",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_tables_nationalityId",
                table: "Authors",
                newName: "IX_Authors_nationalityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Nationalities_nationalityId",
                table: "Authors",
                column: "nationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_authorId",
                table: "Books",
                column: "authorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Nationalities_nationalityId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_authorId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "tables");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_nationalityId",
                table: "tables",
                newName: "IX_tables_nationalityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tables",
                table: "tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_tables_authorId",
                table: "Books",
                column: "authorId",
                principalTable: "tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tables_Nationalities_nationalityId",
                table: "tables",
                column: "nationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
