﻿// <auto-generated />
using EFModeling.FluentAPI.Required;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFMigrations.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200516192004_Seed2")]
    partial class Seed2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("EFModeling.FluentAPI.Required.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            BlogId = 1,
                            Url = "http://sample.com"
                        });
                });

            modelBuilder.Entity("EFModeling.FluentAPI.Required.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BlogId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            BlogId = 1,
                            Content = "Test 1",
                            Title = "First post"
                        });
                });

            modelBuilder.Entity("EFModeling.FluentAPI.Required.Post", b =>
                {
                    b.HasOne("EFModeling.FluentAPI.Required.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
