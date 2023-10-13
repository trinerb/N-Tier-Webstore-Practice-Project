using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Frank Herbert", "Before Matrix, before Star Wars, before Ender's Game and Neuromancer, there was Dune, one of the greatest science fiction novels ever written.", "978-0-340-96019-6", 169.0, 99.0, 129.0, "Dune" },
                    { 2, "Fyodor Dostoevsky", "Rodion Raskolnikov is a handsome, yet impoverished student. Morally conflicted, he believes that extraordinary men who contribute much to society by their thinking are above the law, and in order to prove his theory, he decides to murder a grasping old money lender and, through unforeseen circumstances, her sister.  ", "978-1-78599-644-3", 89.0, 55.0, 69.0, "Crime and Punishment" },
                    { 3, "Scott Jurek", "Scott Jurek is a world-renowned ultramarathon champion who trains and races on a plant-based diet. He has appeared in two New York Times bestsellers, Born to Run and The 4-Hour Body.", "978-0-544-00231-9", 216.0, 128.0, 168.0, "Eat & Run" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
