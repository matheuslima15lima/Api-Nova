﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapi.HealthClinic.tarde.Migrations
{
    /// <inheritdoc />
    public partial class Bd_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Interval",
                table: "Clinica",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interval",
                table: "Clinica");
        }
    }
}