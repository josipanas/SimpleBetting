using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBetting.Data.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalOdd = table.Column<double>(nullable: false),
                    Stake = table.Column<double>(nullable: false),
                    PossiblePayout = table.Column<double>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HomeWin = table.Column<double>(nullable: true),
                    Draw = table.Column<double>(nullable: true),
                    AwayWin = table.Column<double>(nullable: true),
                    HomeWinOrDraw = table.Column<double>(nullable: true),
                    DrawOrAwayWin = table.Column<double>(nullable: true),
                    HomeOrAwayWin = table.Column<double>(nullable: true),
                    IsTopOffer = table.Column<bool>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SportId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchTickets",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTickets", x => new { x.MatchId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_MatchTickets_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Time" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2019, 2, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2019, 2, 12, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2019, 2, 10, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2019, 2, 9, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2019, 2, 11, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Volleyball" },
                    { 2, "Basketball" },
                    { 3, "Waterpolo" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Balance", "TicketId", "Time", "Type" },
                values: new object[] { 1, 100.0, 100.0, null, new DateTime(2019, 2, 11, 19, 34, 39, 124, DateTimeKind.Local).AddTicks(5249), 0 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "AwayWin", "Draw", "DrawOrAwayWin", "HomeOrAwayWin", "HomeWin", "HomeWinOrDraw", "IsTopOffer", "MatchId" },
                values: new object[,]
                {
                    { 1, 3.0, null, null, 1.1000000000000001, 1.5, null, false, 1 },
                    { 2, 18.300000000000001, null, null, 4.0999999999999996, 5.5, null, true, 1 },
                    { 3, 1.3, null, null, 1.1000000000000001, 5.5, null, false, 2 },
                    { 4, 15.0, 13.5, 7.1500000000000004, null, 1.4399999999999999, 2.1299999999999999, false, 3 },
                    { 5, 20.0, 21.5, 10.15, null, 4.4400000000000004, 5.1299999999999999, true, 3 },
                    { 6, 2.2200000000000002, 7.5, 2.1499999999999999, null, 4.0, 3.1299999999999999, false, 4 },
                    { 7, 1.1000000000000001, 10.0, null, null, 9.8000000000000007, 4.9500000000000002, false, 5 },
                    { 8, 4.0999999999999996, 13.0, null, null, 15.5, 8.0999999999999996, true, 5 },
                    { 9, 1.5, 7.0, 1.24, null, 3.2999999999999998, 2.2400000000000002, false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "MatchId", "Name", "SportId" },
                values: new object[,]
                {
                    { 10, 5, "Jug", 3 },
                    { 9, 5, "Jadran", 3 },
                    { 8, 4, "Split", 2 },
                    { 7, 4, "Alkar", 2 },
                    { 6, 3, "Adria Oil Škrljevo", 2 },
                    { 2, 1, "Split", 1 },
                    { 4, 2, "Mladost", 1 },
                    { 3, 2, "Rovinj", 1 },
                    { 11, 6, "POŠK", 3 },
                    { 1, 1, "Mladost Ribola Kaštela", 1 },
                    { 5, 3, "Cedevita", 2 },
                    { 12, 6, "Mornar", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchTickets_TicketId",
                table: "MatchTickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MatchId",
                table: "Offers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MatchId",
                table: "Teams",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchTickets");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
