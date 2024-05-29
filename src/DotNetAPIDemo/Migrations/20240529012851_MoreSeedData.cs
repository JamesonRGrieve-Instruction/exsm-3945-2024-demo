using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetAPIDemo.Migrations
{
    /// <inheritdoc />
    public partial class MoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "job",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -10, "Lawyer" },
                    { -9, "Chef" },
                    { -8, "Engineer" },
                    { -7, "Firefighter" },
                    { -6, "Police Officer" },
                    { -5, "Doctor" },
                    { -4, "Nurse" },
                    { -3, "Teacher" },
                    { -2, "Software Developer" }
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "first_name", "job_id", "last_name", "phone_number", "user_id" },
                values: new object[,]
                {
                    { -22, "Nancy", -1, "Garcia", "", null },
                    { -12, "Barbara", -1, "Wilson", "", null },
                    { -30, "Margaret", -9, "Hall", "", null },
                    { -29, "Andrew", -8, "Walker", "", null },
                    { -28, "Dorothy", -7, "Lee", "", null },
                    { -27, "Anthony", -6, "Lewis", "", null },
                    { -26, "Betty", -5, "Rodriguez", "", null },
                    { -25, "Matthew", -4, "Clark", "", null },
                    { -24, "Lisa", -3, "Robinson", "", null },
                    { -23, "Daniel", -2, "Martinez", "", null },
                    { -21, "Christopher", -10, "Thompson", "", null },
                    { -20, "Karen", -9, "Martin", "", null },
                    { -19, "Charles", -8, "Harris", "", null },
                    { -18, "Sarah", -7, "White", "", null },
                    { -17, "Thomas", -6, "Jackson", "", null },
                    { -16, "Jessica", -5, "Thomas", "", null },
                    { -15, "Joseph", -4, "Taylor", "", null },
                    { -14, "Susan", -3, "Anderson", "", null },
                    { -13, "Richard", -2, "Martinez", "", null },
                    { -11, "David", -10, "Rodriguez", "", null },
                    { -10, "Elizabeth", -9, "Garcia", "", null },
                    { -9, "William", -8, "Davis", "", null },
                    { -8, "Linda", -7, "Miller", "", null },
                    { -7, "Michael", -6, "Jones", "", null },
                    { -6, "Patricia", -5, "Brown", "", null },
                    { -5, "Robert", -4, "Williams", "", null },
                    { -4, "Mary", -3, "Johnson", "", null },
                    { -3, "James", -2, "Smith", "", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -30);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -29);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -28);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -27);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -26);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -25);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "job",
                keyColumn: "id",
                keyValue: -2);
        }
    }
}
