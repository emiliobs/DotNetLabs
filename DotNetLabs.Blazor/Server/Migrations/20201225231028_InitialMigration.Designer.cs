﻿// <auto-generated />
using System;
using DotNetLabs.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetLabs.Blazor.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201225231028_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DotNetLabs.Server.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.Comments", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParentCommentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VideoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("VideoId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.PlayList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreateByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("playLists");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.PlayListVideo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlayListId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VideoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PlayListId");

                    b.HasIndex("VideoId");

                    b.ToTable("playListVideos");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.Tags", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("VideoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.Video", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("CreateByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Privacy")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThumpUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.Comments", b =>
                {
                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", "CreateByUser")
                        .WithMany("CreatedComments")
                        .HasForeignKey("CreateByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", "ModifiedByUser")
                        .WithMany("ModifiedComments")
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DotNetLabs.Server.Models.Comments", "ParentComment")
                        .WithMany("Replys")
                        .HasForeignKey("ParentCommentId");

                    b.HasOne("DotNetLabs.Server.Models.Video", "Video")
                        .WithMany("Comments")
                        .HasForeignKey("VideoId");

                    b.Navigation("CreateByUser");

                    b.Navigation("ModifiedByUser");

                    b.Navigation("ParentComment");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.PlayList", b =>
                {
                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", "CreateByUser")
                        .WithMany("CreatePlayLists")
                        .HasForeignKey("CreateByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", "ModifiedByUser")
                        .WithMany("ModifiedPlayLists")
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreateByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.PlayListVideo", b =>
                {
                    b.HasOne("DotNetLabs.Server.Models.PlayList", "PlayList")
                        .WithMany("PlayListVideos")
                        .HasForeignKey("PlayListId");

                    b.HasOne("DotNetLabs.Server.Models.Video", "Video")
                        .WithMany("PlayListVideos")
                        .HasForeignKey("VideoId");

                    b.Navigation("PlayList");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.Tags", b =>
                {
                    b.HasOne("DotNetLabs.Server.Models.Video", "Video")
                        .WithMany("Tags")
                        .HasForeignKey("VideoId");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.Video", b =>
                {
                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", "CreateByUser")
                        .WithMany("CreateVideos")
                        .HasForeignKey("CreateByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", "ModifiedByUser")
                        .WithMany("ModifiedVideos")
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreateByUser");

                    b.Navigation("ModifiedByUser");
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
                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", null)
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

                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DotNetLabs.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.ApplicationUser", b =>
                {
                    b.Navigation("CreatedComments");

                    b.Navigation("CreatePlayLists");

                    b.Navigation("CreateVideos");

                    b.Navigation("ModifiedComments");

                    b.Navigation("ModifiedPlayLists");

                    b.Navigation("ModifiedVideos");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.Comments", b =>
                {
                    b.Navigation("Replys");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.PlayList", b =>
                {
                    b.Navigation("PlayListVideos");
                });

            modelBuilder.Entity("DotNetLabs.Server.Models.Video", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PlayListVideos");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
