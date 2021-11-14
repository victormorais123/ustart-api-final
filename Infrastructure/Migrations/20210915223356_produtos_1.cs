using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UStart.Infrastructure.Migrations
{
    public partial class produtos_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_produtos_grupo_produtos_grupo_produto_id",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "grupo_id",
                table: "produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "grupo_produto_id",
                table: "produtos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_produtos_grupo_produtos_grupo_produto_id",
                table: "produtos",
                column: "grupo_produto_id",
                principalTable: "grupo_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_produtos_grupo_produtos_grupo_produto_id",
                table: "produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "grupo_produto_id",
                table: "produtos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "grupo_id",
                table: "produtos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "fk_produtos_grupo_produtos_grupo_produto_id",
                table: "produtos",
                column: "grupo_produto_id",
                principalTable: "grupo_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
