using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.ByteBank.Dados.Migrations
{
    public partial class PopulandoByteBankDenovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `agencia` VALUES (null,321,'Banco do Brasil','Av: Societária,91','1447c0e7-c328-47e0-a39f-116e5ab597b3');");

            migrationBuilder.Sql("INSERT INTO `cliente` VALUES (null,'154.125.458-87','Rafael Cunha','Developer','531e5270-8a80-4a2c-8b20-f10182f728fc');");
    
            migrationBuilder.Sql("INSERT INTO `conta_corrente` VALUES(null,5784, 1, 1, 300, '1001b6f8-4fdb-44dd-a63d-850e6bf5e1d3', '00000000-0000-0000-0000-000000000000');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
