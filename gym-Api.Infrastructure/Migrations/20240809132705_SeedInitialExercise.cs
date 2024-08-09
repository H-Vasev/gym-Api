using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gym_Api.Infrastructure.Migrations
{
    public partial class SeedInitialExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Duration", "FileName", "Url" },
                values: new object[,]
                {
                    { 1, "Seconds", 30, "video-01", "/videos/video-01.mp4" },
                    { 2, "Seconds", 30, "video-02", "/videos/video-02.mp4" },
                    { 3, "Times", 30, "video-03", "/videos/video-03.mp4" },
                    { 4, "Seconds", 30, "video-04", "/videos/video-04.mp4" },
                    { 5, "Times", 30, "video-05", "/videos/video-05.mp4" },
                    { 6, "Seconds", 30, "video-06", "/videos/video-06.mp4" },
                    { 7, "Seconds", 30, "video-07", "/videos/video-07.mp4" },
                    { 8, "Seconds", 30, "video-08", "/videos/video-08.mp4" },
                    { 9, "Seconds", 30, "video-09", "/videos/video-09.mp4" },
                    { 10, "Seconds", 30, "video-10", "/videos/video-10.mp4" },
                    { 11, "Seconds", 30, "video-11", "/videos/video-11.mp4" },
                    { 12, "Seconds", 30, "video-12", "/videos/video-12.mp4" },
                    { 13, "Seconds", 30, "video-13", "/videos/video-13.mp4" },
                    { 14, "Seconds", 30, "video-14", "/videos/video-14.mp4" },
                    { 15, "Seconds", 30, "video-15", "/videos/video-15.mp4" },
                    { 16, "Seconds", 30, "video-16", "/videos/video-16.mp4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
