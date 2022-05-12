using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace Carbon.Sample.API.MSSQL.Migrations
{
	public partial class initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "EntitySolutionRelation",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					EntityCode = table.Column<int>(type: "int", nullable: false),
					SolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false),
					UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					DeletedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
					DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
					InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EntitySolutionRelation", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "SampleEntity",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
					IsActive = table.Column<bool>(type: "bit", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false),
					TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					DeletedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
					DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					InsertedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
					InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					OwnerType = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SampleEntity", x => x.Id);
				});

			migrationBuilder.CreateIndex(
				name: "IX_EntitySolutionRelation_EntityCode_EntityId_IsDeleted",
				table: "EntitySolutionRelation",
				columns: new[] { "EntityCode", "EntityId", "IsDeleted" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "EntitySolutionRelation");

			migrationBuilder.DropTable(
				name: "SampleEntity");
		}
	}
}
