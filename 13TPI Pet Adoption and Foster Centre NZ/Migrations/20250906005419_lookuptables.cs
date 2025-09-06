using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class lookuptables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShelterType",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "PetGroupName",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PetStatus",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "AccessLevel",
                table: "AdminOffice");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AdminOffice");

            migrationBuilder.RenameColumn(
                name: "PeGroupDescriptiom",
                table: "PetGroup",
                newName: "PetGroupDescription");

            migrationBuilder.AlterColumn<string>(
                name: "OperatingHours",
                table: "Shelter",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Shelter",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Shelter",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShelterTypeID",
                table: "Shelter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PetGroupID",
                table: "Pet",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PetStatusID",
                table: "Pet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodID",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatusID",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeID",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VisitDate",
                table: "MedicalRecord",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "VaccinationStatus",
                table: "MedicalRecord",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "StatusNameVaccinationStatusID",
                table: "MedicalRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Coordinator",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccessLevelID",
                table: "AdminOffice",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AdminOffice",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelName",
                table: "AdminOffice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TitleID",
                table: "AdminOffice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TitleName",
                table: "AdminOffice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AccessLevel",
                columns: table => new
                {
                    AccessLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevel", x => x.AccessLevelID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    PaymentStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.PaymentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    PaymentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.PaymentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PetStatus",
                columns: table => new
                {
                    PetStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetStatus", x => x.PetStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ShelterType",
                columns: table => new
                {
                    ShelterTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterType", x => x.ShelterTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleID);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationStatus",
                columns: table => new
                {
                    VaccinationStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationStatus", x => x.VaccinationStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_FranchiseID",
                table: "Shelter",
                column: "FranchiseID");

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_LocationID",
                table: "Shelter",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_ShelterTypeID",
                table: "Shelter",
                column: "ShelterTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetGroupID",
                table: "Pet",
                column: "PetGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetStatusID",
                table: "Pet",
                column: "PetStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentMethodID",
                table: "Payment",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentStatusID",
                table: "Payment",
                column: "PaymentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentTypeID",
                table: "Payment",
                column: "PaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_PetID",
                table: "MedicalRecord",
                column: "PetID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_StatusNameVaccinationStatusID",
                table: "MedicalRecord",
                column: "StatusNameVaccinationStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Franchise_LocationID",
                table: "Franchise",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinator_FranchiseID",
                table: "Coordinator",
                column: "FranchiseID");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinator_PetGroupID",
                table: "Coordinator",
                column: "PetGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_AdminOffice_AccessLevelID",
                table: "AdminOffice",
                column: "AccessLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_AdminOffice_TitleID",
                table: "AdminOffice",
                column: "TitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminOffice_AccessLevel_AccessLevelID",
                table: "AdminOffice",
                column: "AccessLevelID",
                principalTable: "AccessLevel",
                principalColumn: "AccessLevelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminOffice_Title_TitleID",
                table: "AdminOffice",
                column: "TitleID",
                principalTable: "Title",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinator_Franchise_FranchiseID",
                table: "Coordinator",
                column: "FranchiseID",
                principalTable: "Franchise",
                principalColumn: "FranchiseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinator_PetGroup_PetGroupID",
                table: "Coordinator",
                column: "PetGroupID",
                principalTable: "PetGroup",
                principalColumn: "PetGroupID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Franchise_Location_LocationID",
                table: "Franchise",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Pet_PetID",
                table: "MedicalRecord",
                column: "PetID",
                principalTable: "Pet",
                principalColumn: "PetID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_VaccinationStatus_StatusNameVaccinationStatusID",
                table: "MedicalRecord",
                column: "StatusNameVaccinationStatusID",
                principalTable: "VaccinationStatus",
                principalColumn: "VaccinationStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentMethod_PaymentMethodID",
                table: "Payment",
                column: "PaymentMethodID",
                principalTable: "PaymentMethod",
                principalColumn: "PaymentMethodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentStatus_PaymentStatusID",
                table: "Payment",
                column: "PaymentStatusID",
                principalTable: "PaymentStatus",
                principalColumn: "PaymentStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentType_PaymentTypeID",
                table: "Payment",
                column: "PaymentTypeID",
                principalTable: "PaymentType",
                principalColumn: "PaymentTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_PetGroup_PetGroupID",
                table: "Pet",
                column: "PetGroupID",
                principalTable: "PetGroup",
                principalColumn: "PetGroupID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_PetStatus_PetStatusID",
                table: "Pet",
                column: "PetStatusID",
                principalTable: "PetStatus",
                principalColumn: "PetStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelter_Franchise_FranchiseID",
                table: "Shelter",
                column: "FranchiseID",
                principalTable: "Franchise",
                principalColumn: "FranchiseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelter_Location_LocationID",
                table: "Shelter",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelter_ShelterType_ShelterTypeID",
                table: "Shelter",
                column: "ShelterTypeID",
                principalTable: "ShelterType",
                principalColumn: "ShelterTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminOffice_AccessLevel_AccessLevelID",
                table: "AdminOffice");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminOffice_Title_TitleID",
                table: "AdminOffice");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinator_Franchise_FranchiseID",
                table: "Coordinator");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinator_PetGroup_PetGroupID",
                table: "Coordinator");

            migrationBuilder.DropForeignKey(
                name: "FK_Franchise_Location_LocationID",
                table: "Franchise");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Pet_PetID",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_VaccinationStatus_StatusNameVaccinationStatusID",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentMethod_PaymentMethodID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentStatus_PaymentStatusID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentType_PaymentTypeID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_PetGroup_PetGroupID",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_PetStatus_PetStatusID",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelter_Franchise_FranchiseID",
                table: "Shelter");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelter_Location_LocationID",
                table: "Shelter");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelter_ShelterType_ShelterTypeID",
                table: "Shelter");

            migrationBuilder.DropTable(
                name: "AccessLevel");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "PetStatus");

            migrationBuilder.DropTable(
                name: "ShelterType");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "VaccinationStatus");

            migrationBuilder.DropIndex(
                name: "IX_Shelter_FranchiseID",
                table: "Shelter");

            migrationBuilder.DropIndex(
                name: "IX_Shelter_LocationID",
                table: "Shelter");

            migrationBuilder.DropIndex(
                name: "IX_Shelter_ShelterTypeID",
                table: "Shelter");

            migrationBuilder.DropIndex(
                name: "IX_Pet_PetGroupID",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_PetStatusID",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PaymentMethodID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PaymentStatusID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PaymentTypeID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecord_PetID",
                table: "MedicalRecord");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecord_StatusNameVaccinationStatusID",
                table: "MedicalRecord");

            migrationBuilder.DropIndex(
                name: "IX_Franchise_LocationID",
                table: "Franchise");

            migrationBuilder.DropIndex(
                name: "IX_Coordinator_FranchiseID",
                table: "Coordinator");

            migrationBuilder.DropIndex(
                name: "IX_Coordinator_PetGroupID",
                table: "Coordinator");

            migrationBuilder.DropIndex(
                name: "IX_AdminOffice_AccessLevelID",
                table: "AdminOffice");

            migrationBuilder.DropIndex(
                name: "IX_AdminOffice_TitleID",
                table: "AdminOffice");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "ShelterTypeID",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "PetGroupID",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PetStatusID",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PaymentMethodID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentStatusID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentTypeID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "StatusNameVaccinationStatusID",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "AccessLevelID",
                table: "AdminOffice");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AdminOffice");

            migrationBuilder.DropColumn(
                name: "LevelName",
                table: "AdminOffice");

            migrationBuilder.DropColumn(
                name: "TitleID",
                table: "AdminOffice");

            migrationBuilder.DropColumn(
                name: "TitleName",
                table: "AdminOffice");

            migrationBuilder.RenameColumn(
                name: "PetGroupDescription",
                table: "PetGroup",
                newName: "PeGroupDescriptiom");

            migrationBuilder.AlterColumn<string>(
                name: "OperatingHours",
                table: "Shelter",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Shelter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShelterType",
                table: "Shelter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Shelter",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PetGroupName",
                table: "Pet",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PetStatus",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Pet",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Payment",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Payment",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VisitDate",
                table: "MedicalRecord",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "VaccinationStatus",
                table: "MedicalRecord",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Coordinator",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "AccessLevel",
                table: "AdminOffice",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AdminOffice",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
        }
    }
}
