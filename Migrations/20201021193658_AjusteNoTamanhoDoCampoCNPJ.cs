using Microsoft.EntityFrameworkCore.Migrations;

namespace RodonavesAPI.Migrations
{
    public partial class AjusteNoTamanhoDoCampoCNPJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Fornecedor",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11) CHARACTER SET utf8mb4",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Fornecedor",
                type: "varchar(11) CHARACTER SET utf8mb4",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }
    }
}
