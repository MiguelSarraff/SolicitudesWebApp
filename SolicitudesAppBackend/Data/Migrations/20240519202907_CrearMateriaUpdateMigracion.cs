using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CrearMateriaUpdateMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "materiaNombre",
                table: "Materias",
                newName: "MateriaNombre");

            migrationBuilder.RenameColumn(
                name: "materiaCreditos",
                table: "Materias",
                newName: "MateriaCreditos");

            migrationBuilder.RenameColumn(
                name: "materiaCodigo",
                table: "Materias",
                newName: "MateriaCodigo");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Materias",
                newName: "Estado");

            migrationBuilder.AlterColumn<string>(
                name: "MateriaCreditos",
                table: "Materias",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MateriaNombre",
                table: "Materias",
                newName: "materiaNombre");

            migrationBuilder.RenameColumn(
                name: "MateriaCreditos",
                table: "Materias",
                newName: "materiaCreditos");

            migrationBuilder.RenameColumn(
                name: "MateriaCodigo",
                table: "Materias",
                newName: "materiaCodigo");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Materias",
                newName: "estado");

            migrationBuilder.AlterColumn<string>(
                name: "materiaCreditos",
                table: "Materias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);
        }
    }
}
