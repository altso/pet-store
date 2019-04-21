using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    RegistrationTimestamp = table.Column<DateTime>(nullable: false),
                    PetType = table.Column<string>(nullable: false),
                    WhiskersLength = table.Column<double>(nullable: true),
                    PackSize = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "DateOfBirth", "Name", "PetType", "RegistrationTimestamp", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2016, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sadie", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 421, DateTimeKind.Local).AddTicks(3187), 1 },
                    { 28, new DateTime(2016, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luna", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(770), 0 },
                    { 29, new DateTime(2016, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lily", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(773), 2 },
                    { 30, new DateTime(2015, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chloe", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(777), 2 },
                    { 31, new DateTime(2017, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loki", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(780), 0 },
                    { 32, new DateTime(2016, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leo", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(784), 2 },
                    { 33, new DateTime(2016, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sir Leonardo ScraggleBottoms III", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(787), 0 },
                    { 34, new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(791), 0 },
                    { 35, new DateTime(2016, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mia", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(794), 0 },
                    { 36, new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(797), 1 },
                    { 37, new DateTime(2016, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professor McGonagall", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(801), 2 },
                    { 38, new DateTime(2016, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(804), 0 },
                    { 39, new DateTime(2016, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cooper", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(807), 1 },
                    { 40, new DateTime(2016, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(811), 2 },
                    { 41, new DateTime(2015, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Molly", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(814), 1 },
                    { 42, new DateTime(2015, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teddy", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(818), 0 },
                    { 43, new DateTime(2015, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peppurrcorn VonPuskins", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(821), 1 },
                    { 44, new DateTime(2015, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(825), 1 },
                    { 45, new DateTime(2015, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daisy", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(829), 2 },
                    { 46, new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tucker", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(832), 2 },
                    { 47, new DateTime(2015, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lola", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(835), 1 },
                    { 48, new DateTime(2017, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chloe", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(839), 1 },
                    { 27, new DateTime(2016, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocky", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(766), 0 },
                    { 26, new DateTime(2017, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(763), 2 },
                    { 25, new DateTime(2015, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smokey", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(760), 0 },
                    { 24, new DateTime(2015, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(756), 1 },
                    { 2, new DateTime(2015, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophie", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(623), 2 },
                    { 3, new DateTime(2017, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simba", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(678), 2 },
                    { 4, new DateTime(2016, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jasper", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(683), 0 },
                    { 5, new DateTime(2017, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sir Snuggles of Fluffington", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(686), 0 },
                    { 6, new DateTime(2015, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sassafrass", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(693), 1 },
                    { 7, new DateTime(2015, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luna", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(696), 2 },
                    { 8, new DateTime(2016, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buddy", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(700), 2 },
                    { 9, new DateTime(2015, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mooncake", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(703), 2 },
                    { 10, new DateTime(2015, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Judas Stardust", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(707), 2 },
                    { 11, new DateTime(2016, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bentley", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(711), 1 },
                    { 49, new DateTime(2015, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milo", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(842), 1 },
                    { 12, new DateTime(2016, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bella", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(714), 1 },
                    { 14, new DateTime(2017, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maggie", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(721), 0 },
                    { 15, new DateTime(2016, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sugar Britches", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(725), 0 },
                    { 16, new DateTime(2017, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nala", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(728), 0 },
                    { 17, new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lola", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(732), 1 },
                    { 18, new DateTime(2016, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milo", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(736), 2 },
                    { 19, new DateTime(2017, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bella", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(739), 0 },
                    { 20, new DateTime(2016, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emoji", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(743), 0 },
                    { 21, new DateTime(2015, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucy", "Cat", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(746), 1 },
                    { 22, new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daisy", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(749), 0 },
                    { 23, new DateTime(2016, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neil Catrick Harris", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(753), 0 },
                    { 13, new DateTime(2017, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucy", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(718), 2 },
                    { 50, new DateTime(2017, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stella", "Dog", new DateTime(2019, 4, 10, 20, 47, 36, 423, DateTimeKind.Local).AddTicks(845), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
