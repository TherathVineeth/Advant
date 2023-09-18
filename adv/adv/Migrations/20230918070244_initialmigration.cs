using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adv.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    UNIQUEPERSONKEY = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIDDLEINITIAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATEOFBIRTH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERMANENTADDRESSLINE1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERMANENTADDRESSLINE2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERMANENTCITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERMANENTSTATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERMANENTZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERMANENTCOUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEPHONENUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.UNIQUEPERSONKEY);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    MEMBERNUMBER = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PROVIDERID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RXFILLDATA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RXDAYSSUPPLY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QUANTITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNITSOFMEASURE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.MEMBERNUMBER);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    PROVIDERID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIDDLEINITIAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TAXONOMYCODE1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HPSPECIALITYCODE1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAYORID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTRACTED = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.PROVIDERID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Provider");
        }
    }
}
