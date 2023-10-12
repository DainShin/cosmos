using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cosmos.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2700), "Bethesda Game Studios" },
                    { 2, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2705), "CD Projekt Red" },
                    { 3, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2707), "Rockstar Games" },
                    { 4, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2709), "Ubisoft" },
                    { 5, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2711), "Electronic Arts" },
                    { 6, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2712), "Square Enix" },
                    { 7, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2714), "Capcom" },
                    { 8, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2716), "Activision" },
                    { 9, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2717), "Blizzard Entertainment" },
                    { 10, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2719), "Bungie" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2498), "Action games usually involve elements of physical conflict, such as fast paced fighting, combat, racing, platforming, and sometimes exploration.", "Action" },
                    { 2, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2551), "Adventure games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Adventure" },
                    { 3, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2554), "Role-playing games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Role-playing" },
                    { 4, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2556), "Strategy games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Strategy" },
                    { 5, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2558), "Racing games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Racing" },
                    { 6, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2560), "Shooter games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Shooter" },
                    { 7, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2561), "Sports games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Sports" },
                    { 8, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2563), "Puzzle games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Puzzle" },
                    { 9, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2565), "Platformer games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Platformer" },
                    { 10, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2567), "Simulation games are usually story-driven and focus on exploration, character interaction, puzzle solving, and sometimes item manipulation.", "Simulation" }
                });

            migrationBuilder.InsertData(
                table: "Modes",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2671), "Single Player" },
                    { 2, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2676), "Multiplayer" },
                    { 3, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2678), "Co-op" },
                    { 4, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2680), "Massively Multiplayer Online" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2784), "Microsoft Studios" },
                    { 2, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2790), "Sony Interactive Entertainment" },
                    { 3, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2792), "Nintendo" },
                    { 4, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2794), "Sega" },
                    { 5, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2796), "Konami" },
                    { 6, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2798), "Bandai Namco Entertainment" },
                    { 7, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2799), "Bethesda Softworks" },
                    { 8, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2801), "Take-Two Interactive" },
                    { 9, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2803), "Warner Bros. Interactive Entertainment" },
                    { 10, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2805), "Deep Silver" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreatedAt", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2826), "Free", 0.00m },
                    { 2, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2832), "Advanced", 19.99m },
                    { 3, new DateTime(2023, 10, 11, 23, 2, 51, 306, DateTimeKind.Local).AddTicks(2834), "Ultimate", 24.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Modes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Modes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
