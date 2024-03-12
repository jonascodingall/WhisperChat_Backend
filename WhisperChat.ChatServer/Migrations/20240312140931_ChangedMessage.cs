using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhisperChat.ChatServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Payload",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Recipient",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Messages",
                newName: "RecipientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Messages",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payload",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recipient",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
