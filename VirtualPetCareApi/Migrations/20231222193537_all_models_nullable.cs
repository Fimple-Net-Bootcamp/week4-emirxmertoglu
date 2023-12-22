using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPetCareApi.Migrations
{
    /// <inheritdoc />
    public partial class all_models_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Pets_PetId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Pets_PetId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthStatuses_Pets_PetId",
                table: "HealthStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "HealthStatuses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Foods",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Activities",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Pets_PetId",
                table: "Activities",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Pets_PetId",
                table: "Foods",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthStatuses_Pets_PetId",
                table: "HealthStatuses",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Pets_PetId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Pets_PetId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthStatuses_Pets_PetId",
                table: "HealthStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "HealthStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Foods",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Activities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Pets_PetId",
                table: "Activities",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Pets_PetId",
                table: "Foods",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthStatuses_Pets_PetId",
                table: "HealthStatuses",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
