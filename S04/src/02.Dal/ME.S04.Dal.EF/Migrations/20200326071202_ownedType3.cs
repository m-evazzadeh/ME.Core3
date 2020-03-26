using Microsoft.EntityFrameworkCore.Migrations;

namespace ME.S04.Dal.EF.Migrations
{
    public partial class ownedType3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_City",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddress_Floor",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_Pelak",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_Street",
                table: "Invoices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingAddress_City",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Floor",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Pelak",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Street",
                table: "Invoices");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Pelak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.InvoiceId, x.Id });
                    table.ForeignKey(
                        name: "FK_Address_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
