using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yulya_trynova_kt_43_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "head_of_department_id",
                table: "cathedras",
                type: "int",
                nullable: true,
                comment: "Идентификатор заведующего кафедрой");

            migrationBuilder.CreateIndex(
                name: "IX_cathedras_head_of_department_id",
                table: "cathedras",
                column: "head_of_department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cathedra_HeadOfDepartment",
                table: "cathedras",
                column: "head_of_department_id",
                principalTable: "teachers",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cathedra_HeadOfDepartment",
                table: "cathedras");

            migrationBuilder.DropIndex(
                name: "IX_cathedras_head_of_department_id",
                table: "cathedras");

            migrationBuilder.DropColumn(
                name: "head_of_department_id",
                table: "cathedras");
        }
    }
}
