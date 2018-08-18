using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogger.Data.Migrations
{
    public partial class schema_update_foreign_key_ref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Posts_Postid",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_usersid",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_Postid",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_usersid",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Postid",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "usersid",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "blog_id",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_blog_id",
                table: "Posts",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_post_id",
                table: "Comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_user_id",
                table: "Blogs",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_user_id",
                table: "Blogs",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_post_id",
                table: "Comments",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_blog_id",
                table: "Posts",
                column: "blog_id",
                principalTable: "Blogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_user_id",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_post_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_blog_id",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_blog_id",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_post_id",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_user_id",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "blog_id",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "Postid",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usersid",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Postid",
                table: "Blogs",
                column: "Postid");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_usersid",
                table: "Blogs",
                column: "usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Posts_Postid",
                table: "Blogs",
                column: "Postid",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_usersid",
                table: "Blogs",
                column: "usersid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
