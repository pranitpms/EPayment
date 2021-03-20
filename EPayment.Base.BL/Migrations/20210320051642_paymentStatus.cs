using Microsoft.EntityFrameworkCore.Migrations;

namespace EPayment.Base.BL.Migrations
{
    public partial class paymentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentStatusDbSet_PaymentId",
                table: "PaymentStatusDbSet");

            migrationBuilder.AlterColumn<int>(
                name: "SecurityCode",
                table: "PaymentDbSet",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatusDbSet_PaymentId",
                table: "PaymentStatusDbSet",
                column: "PaymentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaymentStatusDbSet_PaymentId",
                table: "PaymentStatusDbSet");

            migrationBuilder.AlterColumn<int>(
                name: "SecurityCode",
                table: "PaymentDbSet",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatusDbSet_PaymentId",
                table: "PaymentStatusDbSet",
                column: "PaymentId");
        }
    }
}
