﻿// <auto-generated />
using System;
using CineWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CineWeb.Data.Migrations
{
    [DbContext(typeof(WebContext))]
    partial class WebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("CineWeb.Data.CineWebUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FavTheater")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CineWeb.Models.Movie", b =>
                {
                    b.Property<uint>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("MoviePromotionID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("NowShowing")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PosterLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RatingMPAA")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Runtime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Synopsis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("TrailerLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("MoviePromotionID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CineWeb.Models.MoviePromotion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PromoCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("PromoDeal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PromoDescript")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("CineWeb.Models.Order", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<uint?>("ShowTimeIdID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserIdId")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ShowTimeIdID");

                    b.HasIndex("UserIdId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CineWeb.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Roles")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CineWeb.Models.ShowTime", b =>
                {
                    b.Property<uint>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint?>("MovieIdID")
                        .HasColumnType("INTEGER");

                    b.Property<uint?>("TheaterIdID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("MovieIdID");

                    b.HasIndex("TheaterIdID");

                    b.ToTable("ShowTimes");
                });

            modelBuilder.Entity("CineWeb.Models.Theater", b =>
                {
                    b.Property<uint>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<byte>("NumCols")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("NumRows")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("CineWeb.Models.Ticket", b =>
                {
                    b.Property<uint>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrderID")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("SeatNumber")
                        .HasColumnType("BLOB");

                    b.Property<uint>("ShowTimeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("TypeName");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CineWeb.Models.TicketType", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Name");

                    b.ToTable("TicketType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CineWeb.Data.CineWebUser", b =>
                {
                    b.HasOne("CineWeb.Models.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("CineWeb.Models.Movie", b =>
                {
                    b.HasOne("CineWeb.Models.MoviePromotion", null)
                        .WithMany("Movies")
                        .HasForeignKey("MoviePromotionID");
                });

            modelBuilder.Entity("CineWeb.Models.Order", b =>
                {
                    b.HasOne("CineWeb.Models.ShowTime", "ShowTimeId")
                        .WithMany()
                        .HasForeignKey("ShowTimeIdID");

                    b.HasOne("CineWeb.Data.CineWebUser", "UserId")
                        .WithMany()
                        .HasForeignKey("UserIdId");

                    b.Navigation("ShowTimeId");

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("CineWeb.Models.ShowTime", b =>
                {
                    b.HasOne("CineWeb.Models.Movie", "MovieId")
                        .WithMany()
                        .HasForeignKey("MovieIdID");

                    b.HasOne("CineWeb.Models.Theater", "TheaterId")
                        .WithMany()
                        .HasForeignKey("TheaterIdID");

                    b.Navigation("MovieId");

                    b.Navigation("TheaterId");
                });

            modelBuilder.Entity("CineWeb.Models.Ticket", b =>
                {
                    b.HasOne("CineWeb.Models.Order", null)
                        .WithMany("Tickets")
                        .HasForeignKey("OrderID");

                    b.HasOne("CineWeb.Models.TicketType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeName");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CineWeb.Data.CineWebUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CineWeb.Data.CineWebUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CineWeb.Data.CineWebUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CineWeb.Data.CineWebUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CineWeb.Models.MoviePromotion", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("CineWeb.Models.Order", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CineWeb.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
