using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addFilmCatgegory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Category_CategoryId",
                table: "FilmCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Film_FilmId",
                table: "FilmCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_filmImages_FilmImageId",
                table: "FilmCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmCategories",
                table: "FilmCategories");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "FilmCategories");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "FilmCategories");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "FilmCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FilmCategories");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "FilmCategories");

            migrationBuilder.RenameTable(
                name: "FilmCategories",
                newName: "FilmCategory");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCategories_FilmImageId",
                table: "FilmCategory",
                newName: "IX_FilmCategory_FilmImageId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCategories_FilmId",
                table: "FilmCategory",
                newName: "IX_FilmCategory_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmCategory",
                table: "FilmCategory",
                columns: new[] { "CategoryId", "FilmId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategory_Category_CategoryId",
                table: "FilmCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategory_Film_FilmId",
                table: "FilmCategory",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategory_filmImages_FilmImageId",
                table: "FilmCategory",
                column: "FilmImageId",
                principalTable: "filmImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategory_Category_CategoryId",
                table: "FilmCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategory_Film_FilmId",
                table: "FilmCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategory_filmImages_FilmImageId",
                table: "FilmCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmCategory",
                table: "FilmCategory");

            migrationBuilder.RenameTable(
                name: "FilmCategory",
                newName: "FilmCategories");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCategory_FilmImageId",
                table: "FilmCategories",
                newName: "IX_FilmCategories_FilmImageId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCategory_FilmId",
                table: "FilmCategories",
                newName: "IX_FilmCategories_FilmId");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "FilmCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "FilmCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "FilmCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FilmCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "FilmCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmCategories",
                table: "FilmCategories",
                columns: new[] { "CategoryId", "FilmId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Category_CategoryId",
                table: "FilmCategories",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Film_FilmId",
                table: "FilmCategories",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_filmImages_FilmImageId",
                table: "FilmCategories",
                column: "FilmImageId",
                principalTable: "filmImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
