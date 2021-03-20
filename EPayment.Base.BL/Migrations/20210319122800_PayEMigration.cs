using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPayment.Base.BL.Migrations
{
    public partial class PayEMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentDbSet",
                columns: table => new
                {
                    PaymentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    CardHolder = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    SecurityCode = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDbSet", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatusDbSet",
                columns: table => new
                {
                    PaymentStatusId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentId = table.Column<long>(nullable: false),
                    PatmentStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatusDbSet", x => x.PaymentStatusId);
                    table.ForeignKey(
                        name: "FK_PaymentStatusDbSet_PaymentDbSet_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentDbSet",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatusDbSet_PaymentId",
                table: "PaymentStatusDbSet",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentStatusDbSet");

            migrationBuilder.DropTable(
                name: "PaymentDbSet");
        }
    }
}
