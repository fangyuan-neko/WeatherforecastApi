using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherforecastApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    fxDate = table.Column<string>(type: "TEXT", nullable: false),
                    sunrise = table.Column<string>(type: "TEXT", nullable: false),
                    sunset = table.Column<string>(type: "TEXT", nullable: false),
                    moonrise = table.Column<string>(type: "TEXT", nullable: false),
                    moonset = table.Column<string>(type: "TEXT", nullable: false),
                    moonPhase = table.Column<string>(type: "TEXT", nullable: false),
                    moonPlaseIcon = table.Column<int>(type: "INTEGER", nullable: false),
                    tempMax = table.Column<int>(type: "INTEGER", nullable: false),
                    tempMin = table.Column<int>(type: "INTEGER", nullable: false),
                    iconDay = table.Column<int>(type: "INTEGER", nullable: false),
                    textDay = table.Column<string>(type: "TEXT", nullable: false),
                    iconNight = table.Column<int>(type: "INTEGER", nullable: false),
                    textNight = table.Column<string>(type: "TEXT", nullable: false),
                    wind360Day = table.Column<int>(type: "INTEGER", nullable: false),
                    windDirDay = table.Column<string>(type: "TEXT", nullable: false),
                    windScaleDay = table.Column<string>(type: "TEXT", nullable: false),
                    windSpeedDay = table.Column<int>(type: "INTEGER", nullable: false),
                    wind360Night = table.Column<int>(type: "INTEGER", nullable: false),
                    windDirNight = table.Column<string>(type: "TEXT", nullable: false),
                    windScaleNight = table.Column<string>(type: "TEXT", nullable: false),
                    windSpeedNight = table.Column<int>(type: "INTEGER", nullable: false),
                    humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    precip = table.Column<double>(type: "REAL", nullable: false),
                    pressure = table.Column<int>(type: "INTEGER", nullable: false),
                    vis = table.Column<int>(type: "INTEGER", nullable: false),
                    cloud = table.Column<int>(type: "INTEGER", nullable: false),
                    uvIndex = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.fxDate);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
