using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LawyerWebSite.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(175)", maxLength: 175, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WokrAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WokrAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WokrAreas_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 1, "Ceza Hukuku", "ceza-hukuku" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 2, "Tazminat Hukuku", "tazminat-hukuku" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 3, "Medeni Hukuk", "medeni-hukuk" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "DateTime", "Picture", "Title", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat", new DateTime(2021, 2, 23, 16, 18, 44, 319, DateTimeKind.Local).AddTicks(7503), "ceza-hukuku.jpeg", "Lorem Ipsum Dolor Sit Amet", "Lorem-ipsum-dolor-sit-amet" },
                    { 2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat", new DateTime(2021, 2, 23, 16, 18, 44, 321, DateTimeKind.Local).AddTicks(6771), "tazminat-hukuku.jpeg", "Lorem Ipsum Dolor Sit Amet", "Lorem-ipsum-dolor-sit-amet-2" },
                    { 3, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus. Nam ut eros suscipit, aliquam magna eget, gravida turpis. Aenean varius neque lectus, eget mollis orci accumsan non. Suspendisse sodales dui nulla. Mauris et diam quis mauris commodo consequat", new DateTime(2021, 2, 23, 16, 18, 44, 321, DateTimeKind.Local).AddTicks(6875), "medeni-hukuk.jpeg", "Lorem Ipsum Dolor Sit Amet", "Lorem-ipsum-dolor-sit-amet-2" }
                });

            migrationBuilder.InsertData(
                table: "WokrAreas",
                columns: new[] { "Id", "CategoryId", "Desciption", "Picture" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.", "ceza-hukuku.jpg" },
                    { 2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.", "tazminat-hukuku.jpg" },
                    { 3, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam sem non odio commodo consectetur. Curabitur sem nunc, maximus sed odio a, faucibus ullamcorper nisl. Fusce in neque turpis. Fusce eget sapien non nibh suscipit eleifend. Nullam enim tortor, laoreet in scelerisque ac, facilisis in nibh. Nulla facilisi. Donec ultricies porttitor rhoncus.", "medeni-hukuk.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WokrAreas_CategoryId",
                table: "WokrAreas",
                column: "CategoryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "WokrAreas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
