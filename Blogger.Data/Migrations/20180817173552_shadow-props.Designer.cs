﻿// <auto-generated />
using System;
using Blogger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blogger.Data.Migrations
{
    [DbContext(typeof(BloggerContext))]
    [Migration("20180817173552_shadow-props")]
    partial class shadowprops
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blogger.Domain.Blog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Postid");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name");

                    b.Property<DateTime>("updated_at");

                    b.Property<int>("user_id");

                    b.Property<int?>("usersid");

                    b.HasKey("id");

                    b.HasIndex("Postid");

                    b.HasIndex("usersid");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Blogger.Domain.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("created_at");

                    b.Property<string>("full_name");

                    b.Property<int>("post_id");

                    b.Property<string>("text");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Blogger.Domain.Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("created_at");

                    b.Property<string>("text");

                    b.Property<string>("title");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Blogger.Domain.PostTag", b =>
                {
                    b.Property<int>("post_id");

                    b.Property<int>("tag_id");

                    b.Property<int?>("Postid");

                    b.Property<int?>("Tagid");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("post_id", "tag_id");

                    b.HasIndex("Postid");

                    b.HasIndex("Tagid");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("Blogger.Domain.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Blogger.Domain.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("created_at");

                    b.Property<string>("name");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Blogger.Domain.Blog", b =>
                {
                    b.HasOne("Blogger.Domain.Post")
                        .WithMany("blogs")
                        .HasForeignKey("Postid");

                    b.HasOne("Blogger.Domain.User", "users")
                        .WithMany()
                        .HasForeignKey("usersid");
                });

            modelBuilder.Entity("Blogger.Domain.PostTag", b =>
                {
                    b.HasOne("Blogger.Domain.Post")
                        .WithMany("posttags")
                        .HasForeignKey("Postid");

                    b.HasOne("Blogger.Domain.Tag")
                        .WithMany("posttags")
                        .HasForeignKey("Tagid");
                });
#pragma warning restore 612, 618
        }
    }
}
