﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowAPI.Migrations
{
    public partial class addedForgot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpires",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedAt",
                table: "users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpires",
                table: "users");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "users");

            migrationBuilder.DropColumn(
                name: "VerifiedAt",
                table: "users");
        }
    }
}
