using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopapp.data.Migrations
{
    /// <inheritdoc />
    public partial class AddingCartEntities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ProducId",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartsItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "CartsItems",
                newName: "IX_CartsItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartId",
                table: "CartsItems",
                newName: "IX_CartsItems_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartsItems",
                table: "CartsItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartsItems_Carts_CartId",
                table: "CartsItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartsItems_Products_ProductId",
                table: "CartsItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartsItems_Carts_CartId",
                table: "CartsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartsItems_Products_ProductId",
                table: "CartsItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartsItems",
                table: "CartsItems");

            migrationBuilder.RenameTable(
                name: "CartsItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_CartsItems_ProductId",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartsItems_CartId",
                table: "CartItem",
                newName: "IX_CartItem_CartId");

            migrationBuilder.AddColumn<int>(
                name: "ProducId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
