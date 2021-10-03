﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class _0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RemoteApi");

            migrationBuilder.EnsureSchema(
                name: "PhoneShop");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "RemoteApi",
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
                    Phone_id = table.Column<int>(type: "int", nullable: true),
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
                name: "Phones",
                schema: "RemoteApi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    slug = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    image = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
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
                    Phone_id = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PriceSubscribers_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                schema: "RemoteApi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_id = table.Column<int>(type: "int", nullable: true),
                    Phone_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    release_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    dimension = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    os = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    storage = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    thumbnail = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    images = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    specifications = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Specifications_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "StockSubscribers",
                schema: "PhoneShop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone_id = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("StockSubscribers_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands",
                schema: "RemoteApi");

            migrationBuilder.DropTable(
                name: "Phones",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "Phones",
                schema: "RemoteApi");

            migrationBuilder.DropTable(
                name: "PriceSubscribers",
                schema: "PhoneShop");

            migrationBuilder.DropTable(
                name: "Specifications",
                schema: "RemoteApi");

            migrationBuilder.DropTable(
                name: "StockSubscribers",
                schema: "PhoneShop");
        }
    }
}
