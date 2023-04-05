using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSourcing.Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrations_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nm_status",
                table: "tb_users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nm_status",
                table: "tb_users");
        }
    }
}
