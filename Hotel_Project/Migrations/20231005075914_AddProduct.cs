using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Project.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advantages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RommeCount = table.Column<int>(type: "int", nullable: false),
                    StageCount = table.Column<int>(type: "int", nullable: false),
                    EntriTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExitTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hotelAddreses",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelAddreses", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_hotelAddreses_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotelGallerys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelGallerys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotelGallerys_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotelRooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RomePrice = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CapaCity = table.Column<int>(type: "int", nullable: false),
                    BedCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelRooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_hotelRooms_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotelRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotelRules_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "advantagesTo",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    AdvantageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advantagesTo", x => new { x.RoomId, x.AdvantageId });
                    table.ForeignKey(
                        name: "FK_advantagesTo_advantages_AdvantageId",
                        column: x => x.AdvantageId,
                        principalTable: "advantages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_advantagesTo_hotelRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "hotelRooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsReserve = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservDate_hotelRooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "hotelRooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_advantagesTo_AdvantageId",
                table: "advantagesTo",
                column: "AdvantageId");

            migrationBuilder.CreateIndex(
                name: "IX_hotelGallerys_HotelId",
                table: "hotelGallerys",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_hotelRooms_HotelId",
                table: "hotelRooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_hotelRules_HotelId",
                table: "hotelRules",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_reservDate_RoomId",
                table: "reservDate",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advantagesTo");

            migrationBuilder.DropTable(
                name: "hotelAddreses");

            migrationBuilder.DropTable(
                name: "hotelGallerys");

            migrationBuilder.DropTable(
                name: "hotelRules");

            migrationBuilder.DropTable(
                name: "reservDate");

            migrationBuilder.DropTable(
                name: "advantages");

            migrationBuilder.DropTable(
                name: "hotelRooms");

            migrationBuilder.DropTable(
                name: "hotels");
        }
    }
}
