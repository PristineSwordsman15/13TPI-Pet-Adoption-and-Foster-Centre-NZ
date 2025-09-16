using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class fixnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecord_StatusNameVaccinationStatusID",
                table: "MedicalRecord");

            migrationBuilder.DropIndex(
                name: "IX_AdminOffice_TitleID",
                table: "AdminOffice");

            migrationBuilder.DropColumn(
                name: "AvailableBeds",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "OccupiedBeds",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "OperatingHours",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "ShelterName",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "StatusName",
                table: "PetStatus");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "PetGroup");

            migrationBuilder.DropColumn(
                name: "PetGroupDescription",
                table: "PetGroup");

            migrationBuilder.DropColumn(
                name: "PetID",
                table: "PetGroup");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PetAge",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "PetName",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ClinicName",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "SpecialNeeds",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "StatusNameVaccinationStatusID",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Treatment",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "VetName",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "Franchise");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Franchise");

            migrationBuilder.DropColumn(
                name: "OperatingHours",
                table: "Franchise");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Franchise");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "Coordinator");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Coordinator");

            migrationBuilder.DropColumn(
                name: "ExperienceLevel",
                table: "Coordinator");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Coordinator");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Coordinator");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "Shelter",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                table: "Pet",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Payment",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "VisitDate",
                table: "MedicalRecord",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "VaccinationStatus",
                table: "MedicalRecord",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "MicrochipID",
                table: "MedicalRecord",
                newName: "VaccinationStatusID");

            migrationBuilder.AlterColumn<string>(
                name: "TitleName",
                table: "Title",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PetStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PetGroupName",
                table: "PetGroup",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PaymentType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "PaymentStatus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PaymentMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FranchiseName",
                table: "Franchise",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Coordinator",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Coordinator",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_VaccinationStatusID",
                table: "MedicalRecord",
                column: "VaccinationStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinator_Franchise_FranchiseID",
                table: "Coordinator",
                column: "FranchiseID",
                principalTable: "Franchise",
                principalColumn: "FranchiseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinator_PetGroup_PetGroupID",
                table: "Coordinator",
                column: "PetGroupID",
                principalTable: "PetGroup",
                principalColumn: "PetGroupID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Pet_PetID",
                table: "MedicalRecord",
                column: "PetID",
                principalTable: "Pet",
                principalColumn: "PetID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_VaccinationStatus_VaccinationStatusID",
                table: "MedicalRecord",
                column: "VaccinationStatusID",
                principalTable: "VaccinationStatus",
                principalColumn: "VaccinationStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentMethod_PaymentMethodID",
                table: "Payment",
                column: "PaymentMethodID",
                principalTable: "PaymentMethod",
                principalColumn: "PaymentMethodID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentStatus_PaymentStatusID",
                table: "Payment",
                column: "PaymentStatusID",
                principalTable: "PaymentStatus",
                principalColumn: "PaymentStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentType_PaymentTypeID",
                table: "Payment",
                column: "PaymentTypeID",
                principalTable: "PaymentType",
                principalColumn: "PaymentTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_PetGroup_PetGroupID",
                table: "Pet",
                column: "PetGroupID",
                principalTable: "PetGroup",
                principalColumn: "PetGroupID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_PetStatus_PetStatusID",
                table: "Pet",
                column: "PetStatusID",
                principalTable: "PetStatus",
                principalColumn: "PetStatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelter_Franchise_FranchiseID",
                table: "Shelter",
                column: "FranchiseID",
                principalTable: "Franchise",
                principalColumn: "FranchiseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelter_Location_LocationID",
                table: "Shelter",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinator_Franchise_FranchiseID",
                table: "Coordinator");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinator_PetGroup_PetGroupID",
                table: "Coordinator");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Pet_PetID",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_VaccinationStatus_VaccinationStatusID",
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

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecord_VaccinationStatusID",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PetStatus");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Shelter",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Pet",
                newName: "ArrivalDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Payment",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "VaccinationStatusID",
                table: "MedicalRecord",
                newName: "MicrochipID");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "MedicalRecord",
                newName: "VaccinationStatus");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "MedicalRecord",
                newName: "VisitDate");

            migrationBuilder.AlterColumn<string>(
                name: "TitleName",
                table: "Title",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AvailableBeds",
                table: "Shelter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Shelter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Shelter",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OccupiedBeds",
                table: "Shelter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OperatingHours",
                table: "Shelter",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShelterName",
                table: "Shelter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatusName",
                table: "PetStatus",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PetGroupName",
                table: "PetGroup",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "PetGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PetGroupDescription",
                table: "PetGroup",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PetID",
                table: "PetGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Pet",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PetAge",
                table: "Pet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PetName",
                table: "Pet",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Pet",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PaymentType",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "PaymentStatus",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MethodName",
                table: "PaymentMethod",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClinicName",
                table: "MedicalRecord",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "MedicalRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialNeeds",
                table: "MedicalRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatusNameVaccinationStatusID",
                table: "MedicalRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Treatment",
                table: "MedicalRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VetName",
                table: "MedicalRecord",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FranchiseName",
                table: "Franchise",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "Franchise",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Franchise",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatingHours",
                table: "Franchise",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Franchise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Coordinator",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Coordinator",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "Coordinator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Coordinator",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExperienceLevel",
                table: "Coordinator",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Coordinator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Coordinator",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_StatusNameVaccinationStatusID",
                table: "MedicalRecord",
                column: "StatusNameVaccinationStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AdminOffice_TitleID",
                table: "AdminOffice",
                column: "TitleID");

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
        }
    }
}
