using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    countryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.countryId);
                });

            migrationBuilder.CreateTable(
                name: "IncidentListViewModel",
                columns: table => new
                {
                    IncidentListViewModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentListViewModel", x => x.IncidentListViewModelId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productPrice = table.Column<double>(type: "float", nullable: false),
                    productReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    technicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    technicianFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    technicianEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    technicianPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.technicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerPostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    customerCountryId = table.Column<int>(type: "int", nullable: false),
                    customerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customer_Country_customerCountryId",
                        column: x => x.customerCountryId,
                        principalTable: "Country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    incidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    incidentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    incidentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    incidentCustomerId = table.Column<int>(type: "int", nullable: false),
                    incidentProductId = table.Column<int>(type: "int", nullable: false),
                    incidentTechnicianId = table.Column<int>(type: "int", nullable: true),
                    incidentDateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    incidentDateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncidentListViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.incidentId);
                    table.ForeignKey(
                        name: "FK_Incident_Customer_incidentCustomerId",
                        column: x => x.incidentCustomerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_IncidentListViewModel_IncidentListViewModelId",
                        column: x => x.IncidentListViewModelId,
                        principalTable: "IncidentListViewModel",
                        principalColumn: "IncidentListViewModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_Product_incidentProductId",
                        column: x => x.incidentProductId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Technician_incidentTechnicianId",
                        column: x => x.incidentTechnicianId,
                        principalTable: "Technician",
                        principalColumn: "technicianId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => new { x.customerId, x.productId });
                    table.ForeignKey(
                        name: "FK_Registration_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "countryId", "countryName" },
                values: new object[,]
                {
                    { 1, "Canada" },
                    { 2, "United States of America" },
                    { 3, "United Kingdom" },
                    { 4, "France" },
                    { 5, "Mexico" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productId", "productCode", "productName", "productPrice", "productReleaseDate" },
                values: new object[,]
                {
                    { 7, "DRAFT20", "Draft Manager 2.0", 5.9900000000000002, new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "TRNY20", "Tournament Master 2.0", 5.9900000000000002, new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "TEAM10", "Team Manager 1.0", 4.9900000000000002, new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "DRAFT10", "Draft Manager 1.0", 4.9900000000000002, new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "LEAGD10", "League Scheduler Deluxe 1.0", 7.9900000000000002, new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "LEAG10", "League Scheduler 1.0", 4.9900000000000002, new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "TRNY10", "Tournament Master 1.0", 4.9900000000000002, new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Technician",
                columns: new[] { "technicianId", "technicianEmail", "technicianFullName", "technicianPhone" },
                values: new object[,]
                {
                    { 1, "alison@sportsprosoftware.com", "Alison Diaz", "800-555-0443" },
                    { 2, "awilson@sportsprosoftware.com", "Andrew Wilson", "800-555-0449" },
                    { 3, "gfiori@sportsprosoftware.com", "Gina Fiori", "800-555-0459" },
                    { 4, "gunter@sportsprosoftware.com", "Gunter Wendt", "800-555-0400" },
                    { 5, "jason@sportsprosoftware.com", "Jason Lee", "800-555-0444" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "customerId", "customerAddress", "customerCity", "customerCountryId", "customerEmail", "customerFirstName", "customerLastName", "customerPhone", "customerPostalCode", "customerState" },
                values: new object[,]
                {
                    { 1, "100 Apple Street", "San Francisco", 1, "kanthoni@pge.com", "Kaitlyn", "Anthoni", "555-555-1000", "90001", "California" },
                    { 2, "200 Banana Street", "Washington", 2, "ania@mma.nidc.com", "Ana", "Irvin", "555-555-1001", "90002", "D.C." },
                    { 3, "300 Corn Street", "Mission Viejo", 2, " ", "Gonzalo", "Keeton", "555-555-1002", "90003", "California" },
                    { 4, "400 Dingleberry Street", "Sacramento", 2, "amauro@yahoo.org", "Anton", "Mauro", "555-555-1003", "90004", "Calfiornia" },
                    { 5, "500 Eggfruit Street", "Fresno", 2, "kmayte@fresno.ca.gov", "Kendall", "Mayte", "555-555-1004", "90005", "California" },
                    { 6, "600 Finger Lime Street", "Los Angeles", 2, "kenzie@mma.jobtrack.com", "Kenzie", "Quinn", "555-555-1005", "90006", "California" },
                    { 7, "700 Grape Street", "Fresno", 2, "marvin@expedata.com", "Marvin", "Quintin", "555-555-1006", "90007", "California" }
                });

            migrationBuilder.InsertData(
                table: "Incident",
                columns: new[] { "incidentId", "IncidentListViewModelId", "incidentCustomerId", "incidentDateClosed", "incidentDateOpened", "incidentDescription", "incidentProductId", "incidentTechnicianId", "incidentTitle" },
                values: new object[,]
                {
                    { 3, null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 511, unable to locate database", 3, 3, "Error importing data" },
                    { 2, null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program failed to install with error code 502", 1, 2, "Could not install" },
                    { 1, null, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program failed to install with error code 502", 4, 1, "Could not install" },
                    { 4, null, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database", 2, 4, "Error launching program" }
                });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "customerId", "productId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_customerCountryId",
                table: "Customer",
                column: "customerCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_incidentCustomerId",
                table: "Incident",
                column: "incidentCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IncidentListViewModelId",
                table: "Incident",
                column: "IncidentListViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_incidentProductId",
                table: "Incident",
                column: "incidentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_incidentTechnicianId",
                table: "Incident",
                column: "incidentTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_productId",
                table: "Registration",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "IncidentListViewModel");

            migrationBuilder.DropTable(
                name: "Technician");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
