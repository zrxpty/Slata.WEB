using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slata.DAL.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Applicants_ApplicantId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Positions_PositionId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ApplicantId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PositionId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("349b5122-1f49-4150-99e3-19266b6ddfaf"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7aa2cd92-88f0-4d17-b63f-775910a8a659"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("9edfff9f-128e-4998-b37f-9976e34a9f8a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0be7c1dd-14e0-483c-9998-f5a758cf980b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("44f43bfe-4ec7-4de5-9732-485d3348dbaa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("989037ab-b998-4a1b-9d71-9beb0f6d3201"));

            migrationBuilder.AlterColumn<string>(
                name: "PositionId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4b0c4854-8969-40c0-a794-f3d4a1fd2ecf"), "fullstack developer" },
                    { new Guid("58219188-e50b-4b7a-a12c-8e76777c502d"), "Middle C#" },
                    { new Guid("d989838f-47f2-46bb-aaba-948791e16bac"), "Senior C#" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1281ddd6-6913-4382-8e9a-11c5b0664c69"), "teamlead" },
                    { new Guid("dc058331-7d09-49b2-8ee0-02d142a05263"), "hr" },
                    { new Guid("f9e51c87-f9e8-4d41-97de-63218f4f9a2f"), "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("4b0c4854-8969-40c0-a794-f3d4a1fd2ecf"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("58219188-e50b-4b7a-a12c-8e76777c502d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d989838f-47f2-46bb-aaba-948791e16bac"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1281ddd6-6913-4382-8e9a-11c5b0664c69"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dc058331-7d09-49b2-8ee0-02d142a05263"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f9e51c87-f9e8-4d41-97de-63218f4f9a2f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("349b5122-1f49-4150-99e3-19266b6ddfaf"), "fullstack developer" },
                    { new Guid("7aa2cd92-88f0-4d17-b63f-775910a8a659"), "Senior C#" },
                    { new Guid("9edfff9f-128e-4998-b37f-9976e34a9f8a"), "Middle C#" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0be7c1dd-14e0-483c-9998-f5a758cf980b"), "teamlead" },
                    { new Guid("44f43bfe-4ec7-4de5-9732-485d3348dbaa"), "admin" },
                    { new Guid("989037ab-b998-4a1b-9d71-9beb0f6d3201"), "hr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ApplicantId",
                table: "Tasks",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PositionId",
                table: "Tasks",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Applicants_ApplicantId",
                table: "Tasks",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Positions_PositionId",
                table: "Tasks",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");
        }
    }
}
