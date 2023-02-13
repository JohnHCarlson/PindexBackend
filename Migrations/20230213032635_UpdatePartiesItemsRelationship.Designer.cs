﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PindexBackend.Models;

#nullable disable

namespace PindexBackend.Migrations
{
    [DbContext(typeof(PindexContext))]
    [Migration("20230213032635_UpdatePartiesItemsRelationship")]
    partial class UpdatePartiesItemsRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategorizationItem", b =>
                {
                    b.Property<int>("CategorizationsCategorizationId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemsItemId")
                        .HasColumnType("integer");

                    b.HasKey("CategorizationsCategorizationId", "ItemsItemId");

                    b.HasIndex("ItemsItemId");

                    b.ToTable("ItemCategorizations", (string)null);
                });

            modelBuilder.Entity("IssueItem", b =>
                {
                    b.Property<int>("IssuesIssueId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemsItemId")
                        .HasColumnType("integer");

                    b.HasKey("IssuesIssueId", "ItemsItemId");

                    b.HasIndex("ItemsItemId");

                    b.ToTable("ItemIssues", (string)null);
                });

            modelBuilder.Entity("PindexBackend.Models.Canorg", b =>
                {
                    b.Property<int>("CanorgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CanorgId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CanorgId");

                    b.HasIndex("ItemId");

                    b.ToTable("Canorgs");
                });

            modelBuilder.Entity("PindexBackend.Models.Categorization", b =>
                {
                    b.Property<int>("CategorizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategorizationId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategorizationId");

                    b.ToTable("Categorization");
                });

            modelBuilder.Entity("PindexBackend.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImageId"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ImageId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PindexBackend.Models.Issue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IssueId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IssueId");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("PindexBackend.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<DateTime?>("ElectionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("StorageLocation")
                        .HasColumnType("text");

                    b.Property<bool?>("Won")
                        .HasColumnType("boolean");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PindexBackend.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("PindexBackend.Models.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OfficeId");

                    b.ToTable("Office");
                });

            modelBuilder.Entity("PindexBackend.Models.Party", b =>
                {
                    b.Property<int>("PartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PartyId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PartyId");

                    b.HasIndex("ItemId");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("CategorizationItem", b =>
                {
                    b.HasOne("PindexBackend.Models.Categorization", null)
                        .WithMany()
                        .HasForeignKey("CategorizationsCategorizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PindexBackend.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IssueItem", b =>
                {
                    b.HasOne("PindexBackend.Models.Issue", null)
                        .WithMany()
                        .HasForeignKey("IssuesIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PindexBackend.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PindexBackend.Models.Canorg", b =>
                {
                    b.HasOne("PindexBackend.Models.Item", "Item")
                        .WithMany("Canorgs")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PindexBackend.Models.Image", b =>
                {
                    b.HasOne("PindexBackend.Models.Item", "Item")
                        .WithOne("Image")
                        .HasForeignKey("PindexBackend.Models.Image", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PindexBackend.Models.Location", b =>
                {
                    b.HasOne("PindexBackend.Models.Item", "Item")
                        .WithMany("Locations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PindexBackend.Models.Office", b =>
                {
                    b.HasOne("PindexBackend.Models.Item", "Item")
                        .WithMany("Offices")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PindexBackend.Models.Party", b =>
                {
                    b.HasOne("PindexBackend.Models.Item", "Item")
                        .WithMany("Parties")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PindexBackend.Models.Item", b =>
                {
                    b.Navigation("Canorgs");

                    b.Navigation("Image");

                    b.Navigation("Locations");

                    b.Navigation("Offices");

                    b.Navigation("Parties");
                });
#pragma warning restore 612, 618
        }
    }
}
