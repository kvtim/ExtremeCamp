using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Meetups.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Participants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Meetups",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 12, 32, 46, 245, DateTimeKind.Local).AddTicks(4373),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 5, 2, 12, 57, 53, 500, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MeetupId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Meetups_MeetupId",
                        column: x => x.MeetupId,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_MeetupId",
                table: "Participants",
                column: "MeetupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Meetups",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 2, 12, 57, 53, 500, DateTimeKind.Local).AddTicks(4174),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 5, 4, 12, 32, 46, 245, DateTimeKind.Local).AddTicks(4373));
        }
    }
}
