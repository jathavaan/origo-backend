﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yana.Persistence.Context;

#nullable disable

namespace Yana.Persistence.Migrations
{
    [DbContext(typeof(YanaDbContext))]
    [Migration("20250111173024_AddedExternalUserProfilesEntity")]
    partial class AddedExternalUserProfilesEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Yana.Domain.Entites.Citation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Issue")
                        .HasColumnType("int");

                    b.Property<string>("Pages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<DateOnly>("RetrievedDate")
                        .HasColumnType("date");

                    b.Property<int>("SourceType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Citations");
                });

            modelBuilder.Entity("Yana.Domain.Entites.Document", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GridSize")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Yana.Domain.Entites.DocumentHasTag", b =>
                {
                    b.Property<string>("DocumentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("DocumentId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("DocumentHasTag");
                });

            modelBuilder.Entity("Yana.Domain.Entites.DocumentHasUser", b =>
                {
                    b.Property<string>("DocumentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DocumentId", "UserId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("DocumentHasUser");
                });

            modelBuilder.Entity("Yana.Domain.Entites.DocumentReference", b =>
                {
                    b.Property<string>("ParentDocumentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChildDocumentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ParentDocumentId", "ChildDocumentId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("ChildDocumentId");

                    b.ToTable("DocumentReferences");
                });

            modelBuilder.Entity("Yana.Domain.Entites.ExternalUserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AuthProvider")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExternalUserProfile");
                });

            modelBuilder.Entity("Yana.Domain.Entites.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Yana.Domain.Entites.Tile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("ntext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<int>("XPosition")
                        .HasColumnType("int");

                    b.Property<int>("YPosition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Tiles");
                });

            modelBuilder.Entity("Yana.Domain.Entites.TileHasUser", b =>
                {
                    b.Property<int>("TileId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserProfileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TileId", "UserId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("TileHasUser");
                });

            modelBuilder.Entity("Yana.Domain.Entites.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Yana.Domain.Entites.Citation", b =>
                {
                    b.HasOne("Yana.Domain.Entites.Document", "Document")
                        .WithMany("Citations")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Yana.Domain.Entites.UserProfile", "UserProfile")
                        .WithMany("Citations")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Yana.Domain.Entites.DocumentHasTag", b =>
                {
                    b.HasOne("Yana.Domain.Entites.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yana.Domain.Entites.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Yana.Domain.Entites.DocumentHasUser", b =>
                {
                    b.HasOne("Yana.Domain.Entites.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yana.Domain.Entites.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Yana.Domain.Entites.DocumentReference", b =>
                {
                    b.HasOne("Yana.Domain.Entites.Document", "ChildDocument")
                        .WithMany()
                        .HasForeignKey("ChildDocumentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Yana.Domain.Entites.Document", "ParentDocument")
                        .WithMany()
                        .HasForeignKey("ParentDocumentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChildDocument");

                    b.Navigation("ParentDocument");
                });

            modelBuilder.Entity("Yana.Domain.Entites.ExternalUserProfile", b =>
                {
                    b.HasOne("Yana.Domain.Entites.UserProfile", "User")
                        .WithMany("ExternalUserProfiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Yana.Domain.Entites.Tag", b =>
                {
                    b.HasOne("Yana.Domain.Entites.UserProfile", "UserProfile")
                        .WithMany("Tags")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Yana.Domain.Entites.Tile", b =>
                {
                    b.HasOne("Yana.Domain.Entites.Document", "Document")
                        .WithMany("Tiles")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Yana.Domain.Entites.TileHasUser", b =>
                {
                    b.HasOne("Yana.Domain.Entites.Tile", "Tile")
                        .WithMany()
                        .HasForeignKey("TileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yana.Domain.Entites.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tile");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Yana.Domain.Entites.Document", b =>
                {
                    b.Navigation("Citations");

                    b.Navigation("Tiles");
                });

            modelBuilder.Entity("Yana.Domain.Entites.UserProfile", b =>
                {
                    b.Navigation("Citations");

                    b.Navigation("ExternalUserProfiles");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
