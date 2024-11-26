using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class cartuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_CreateByUserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UpdateByUserId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CreateByUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CreateByUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "UpdateByUserId",
                table: "Carts",
                newName: "ModifiedById");

            migrationBuilder.RenameColumn(
                name: "PositionYaw",
                table: "Carts",
                newName: "Yaw");

            migrationBuilder.RenameColumn(
                name: "PositionPitch",
                table: "Carts",
                newName: "Pitch");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Carts",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UpdateByUserId",
                table: "Carts",
                newName: "IX_Carts_ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CreatedById",
                table: "Carts",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_CreatedById",
                table: "Carts",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_ModifiedById",
                table: "Carts",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_CreatedById",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_ModifiedById",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CreatedById",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Yaw",
                table: "Carts",
                newName: "PositionYaw");

            migrationBuilder.RenameColumn(
                name: "Pitch",
                table: "Carts",
                newName: "PositionPitch");

            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                table: "Carts",
                newName: "UpdateByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Carts",
                newName: "ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_ModifiedById",
                table: "Carts",
                newName: "IX_Carts_UpdateByUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateByUserId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CreateByUserId",
                table: "Carts",
                column: "CreateByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_CreateByUserId",
                table: "Carts",
                column: "CreateByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UpdateByUserId",
                table: "Carts",
                column: "UpdateByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
