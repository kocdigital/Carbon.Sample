using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace Carbon.Sample.API.PostgreSQL.Migrations
{
	public partial class initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "EntitySolutionRelation",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					EntityId = table.Column<Guid>(type: "uuid", nullable: false),
					EntityCode = table.Column<int>(type: "integer", nullable: false),
					SolutionId = table.Column<Guid>(type: "uuid", nullable: false),
					IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
					UpdatedUser = table.Column<string>(type: "text", nullable: true),
					UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
					DeletedUser = table.Column<string>(type: "text", nullable: true),
					DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
					InsertedUser = table.Column<string>(type: "text", nullable: true),
					InsertedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EntitySolutionRelation", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "SampleEntity",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Name = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
					IsActive = table.Column<bool>(type: "boolean", nullable: false),
					IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
					TenantId = table.Column<Guid>(type: "uuid", nullable: false),
					UpdatedUser = table.Column<string>(type: "text", nullable: true),
					UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
					DeletedUser = table.Column<string>(type: "text", nullable: true),
					DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
					InsertedUser = table.Column<string>(type: "text", nullable: true),
					InsertedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
					OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
					OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
					OwnerType = table.Column<int>(type: "integer", nullable: false)
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
