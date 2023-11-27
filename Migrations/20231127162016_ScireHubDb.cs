using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScireHub.Migrations
{
    /// <inheritdoc />
    public partial class ScireHubDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PKUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PKUsuario);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PKUsuario", "Apellido1", "Apellido2", "Contraseña", "Correo", "Nombre", "NombreUsuario" },
                values: new object[] { 1, "Fierro", "Ballote", "robertojunio2004@gmail.com", "1234", "Roberto", "robertofb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
