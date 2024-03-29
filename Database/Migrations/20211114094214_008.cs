﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class _008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PhoneShop");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    slug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Brands_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandSlug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    phoneSlug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    phoneName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    dimension = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    os = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    storage = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    thumbnail = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    release_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    images = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    specifications = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true),
                    hided = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Phones_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PriceSubscribers",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandSlug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    phoneSlug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PriceSubscribers_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "StockSubscribers",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandSlug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    phoneSlug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("StockSubscribers_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    role = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    amount = table.Column<int>(type: "int", nullable: true),
                    discount = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    phoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PromoCodes_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "PromoCodes_Phones_id_fk",
                        column: x => x.phoneId,
                        principalSchema: "PhoneShop",
                        principalTable: "Phones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: true),
                    phoneId = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cart_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Carts_Phones_id_fk",
                        column: x => x.phoneId,
                        principalSchema: "PhoneShop",
                        principalTable: "Phones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Carts_Users_id_fk",
                        column: x => x.userId,
                        principalSchema: "PhoneShop",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneSlug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    comments = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Comments_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Comments_Users_id_fk",
                        column: x => x.userId,
                        principalSchema: "PhoneShop",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishList",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: true),
                    phoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WishList_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "WishList_Phones_id_fk",
                        column: x => x.phoneId,
                        principalSchema: "PhoneShop",
                        principalTable: "Phones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "WishList_Users_id_fk",
                        column: x => x.userId,
                        principalSchema: "PhoneShop",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_phoneId",
                schema: "PhoneShop",
                table: "Carts",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_userId",
                schema: "PhoneShop",
                table: "Carts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                schema: "PhoneShop",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_phoneId",
                schema: "PhoneShop",
                table: "PromoCodes",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "Users_email_uindex",
                schema: "PhoneShop",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishList_phoneId",
                schema: "PhoneShop",
                table: "WishList",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_userId",
                schema: "PhoneShop",
                table: "WishList",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "PriceSubscribers",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "PromoCodes",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "StockSubscribers",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "WishList",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "Phones",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "PhoneShop");
        }
    }
}
