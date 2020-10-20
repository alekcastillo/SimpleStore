using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBookSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBookSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMovieGenres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMovieGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    ReleaseYear = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    PreviewFilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSongGenres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSongGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    BooksSavePath = table.Column<string>(nullable: true),
                    BookPreviewsSavePath = table.Column<string>(nullable: true),
                    SongsSavePath = table.Column<string>(nullable: true),
                    SongPreviewsSavePath = table.Column<string>(nullable: true),
                    MoviesSavePath = table.Column<string>(nullable: true),
                    MoviePreviewsSavePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableConsecutives",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Table = table.Column<string>(nullable: true),
                    Current = table.Column<int>(nullable: false),
                    UsesPrefix = table.Column<bool>(nullable: false),
                    Prefix = table.Column<string>(nullable: true),
                    UsesRange = table.Column<bool>(nullable: false),
                    RangeMin = table.Column<int>(nullable: true),
                    RangeMax = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableConsecutives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethodCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    PaymentMethodId = table.Column<Guid>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    ExpirationMonth = table.Column<int>(nullable: false),
                    ExpirationYear = table.Column<int>(nullable: false),
                    CVV = table.Column<int>(nullable: false),
                    CardProvider = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethodCards_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethodEasyPays",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    PaymentMethodId = table.Column<Guid>(nullable: true),
                    AccountId = table.Column<int>(nullable: false),
                    SecurityNumber = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodEasyPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethodEasyPays_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductBooks",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBooks", x => x.Code);
                    table.ForeignKey(
                        name: "FK_ProductBooks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductBooks_ProductBookSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "ProductBookSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMovies",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    GenreId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMovies", x => x.Code);
                    table.ForeignKey(
                        name: "FK_ProductMovies_ProductMovieGenres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "ProductMovieGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductMovies_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSongs",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    GenreId = table.Column<Guid>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    Album = table.Column<string>(nullable: true),
                    InterpretationType = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSongs", x => x.Code);
                    table.ForeignKey(
                        name: "FK_ProductSongs_ProductSongGenres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "ProductSongGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSongs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    BuyerId = table.Column<Guid>(nullable: true),
                    AmountPayed = table.Column<float>(nullable: false),
                    PaymentMethodCardId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethodCards_PaymentMethodCardId",
                        column: x => x.PaymentMethodCardId,
                        principalTable: "PaymentMethodCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMovieActors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductMovieCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMovieActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMovieActors_ProductMovies_ProductMovieCode",
                        column: x => x.ProductMovieCode,
                        principalTable: "ProductMovies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DownloadLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownloadLogs_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DownloadLogs_OrderId",
                table: "DownloadLogs",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodCardId",
                table: "Orders",
                column: "PaymentMethodCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodCards_PaymentMethodId",
                table: "PaymentMethodCards",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodEasyPays_PaymentMethodId",
                table: "PaymentMethodEasyPays",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBooks_ProductId",
                table: "ProductBooks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBooks_SubjectId",
                table: "ProductBooks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovieActors_ProductMovieCode",
                table: "ProductMovieActors",
                column: "ProductMovieCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovies_GenreId",
                table: "ProductMovies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovies_ProductId",
                table: "ProductMovies",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSongs_GenreId",
                table: "ProductSongs",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSongs_ProductId",
                table: "ProductSongs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DownloadLogs");

            migrationBuilder.DropTable(
                name: "PaymentMethodEasyPays");

            migrationBuilder.DropTable(
                name: "ProductBooks");

            migrationBuilder.DropTable(
                name: "ProductMovieActors");

            migrationBuilder.DropTable(
                name: "ProductSongs");

            migrationBuilder.DropTable(
                name: "SystemConfigurations");

            migrationBuilder.DropTable(
                name: "TableConsecutives");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductBookSubjects");

            migrationBuilder.DropTable(
                name: "ProductMovies");

            migrationBuilder.DropTable(
                name: "ProductSongGenres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PaymentMethodCards");

            migrationBuilder.DropTable(
                name: "ProductMovieGenres");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
