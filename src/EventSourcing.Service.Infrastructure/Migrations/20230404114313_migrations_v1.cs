using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSourcing.Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrations_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_events",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stream_id = table.Column<int>(type: "INTEGER", nullable: false),
                    data_info = table.Column<string>(type: "TEXT", nullable: false),
                    version = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_events", x => x.event_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    cd_user_pk = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nm_user = table.Column<string>(type: "TEXT", nullable: false),
                    nm_password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_users", x => x.cd_user_pk);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_events");

            migrationBuilder.DropTable(
                name: "tb_users");
        }
    }
}
