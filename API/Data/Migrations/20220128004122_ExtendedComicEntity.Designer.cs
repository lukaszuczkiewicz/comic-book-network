﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220128004122_ExtendedComicEntity")]
    partial class ExtendedComicEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Introduction")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Comic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComicSeriesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("IssueNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PageCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ComicSeriesId");

                    b.ToTable("Comic");
                });

            modelBuilder.Entity("API.Entities.ComicComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComicId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("TextContent")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ComicId");

                    b.ToTable("ComicComment");
                });

            modelBuilder.Entity("API.Entities.ComicSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Artist")
                        .HasColumnType("TEXT");

                    b.Property<int>("EndYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Publisher")
                        .HasColumnType("TEXT");

                    b.Property<string>("SeriesName")
                        .HasColumnType("TEXT");

                    b.Property<int>("StartYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Writer")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ComicSeries");
                });

            modelBuilder.Entity("API.Entities.ComicSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComicId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsInCollection")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsInWishlist")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRead")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rate")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ComicId");

                    b.ToTable("ComicSocial");
                });

            modelBuilder.Entity("API.Entities.Comic", b =>
                {
                    b.HasOne("API.Entities.ComicSeries", "ComicSeries")
                        .WithMany("Comics")
                        .HasForeignKey("ComicSeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComicSeries");
                });

            modelBuilder.Entity("API.Entities.ComicComment", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("ComicComments")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Comic", "Comic")
                        .WithMany("ComicComments")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("API.Entities.ComicSocial", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("ComicSocials")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Comic", "Comic")
                        .WithMany("ComicSocials")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("ComicComments");

                    b.Navigation("ComicSocials");
                });

            modelBuilder.Entity("API.Entities.Comic", b =>
                {
                    b.Navigation("ComicComments");

                    b.Navigation("ComicSocials");
                });

            modelBuilder.Entity("API.Entities.ComicSeries", b =>
                {
                    b.Navigation("Comics");
                });
#pragma warning restore 612, 618
        }
    }
}
