﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VehiclesApp.Api.Data;

#nullable disable

namespace vehicles_test_app.Migrations
{
    [DbContext(typeof(VehiclesAppContext))]
    [Migration("20241115131119_migrations")]
    partial class migrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VehiclesApp.Api.Attribute", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("VehiclesApp.Api.AttributeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AttributeName")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AttributeName");

                    b.ToTable("AttributeValues");
                });

            modelBuilder.Entity("VehiclesApp.Api.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehiclesApp.Api.VehicleAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AttributeName")
                        .HasColumnType("text");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AttributeName");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleAttributes");
                });

            modelBuilder.Entity("VehiclesApp.Api.VehicleAttributeValue", b =>
                {
                    b.Property<int>("VehicleAttributeId")
                        .HasColumnType("integer");

                    b.Property<int>("AttributeValueId")
                        .HasColumnType("integer");

                    b.HasKey("VehicleAttributeId", "AttributeValueId");

                    b.HasIndex("AttributeValueId");

                    b.ToTable("VehicleAttributeValues");
                });

            modelBuilder.Entity("VehiclesApp.Api.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");
                });

            modelBuilder.Entity("VehiclesApp.Api.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VehicleMakeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("VehiclesApp.Api.AttributeValue", b =>
                {
                    b.HasOne("VehiclesApp.Api.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeName");

                    b.Navigation("Attribute");
                });

            modelBuilder.Entity("VehiclesApp.Api.Vehicle", b =>
                {
                    b.HasOne("VehiclesApp.Api.VehicleModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("VehiclesApp.Api.VehicleAttribute", b =>
                {
                    b.HasOne("VehiclesApp.Api.Attribute", "Attribute")
                        .WithMany("VehicleAttributes")
                        .HasForeignKey("AttributeName");

                    b.HasOne("VehiclesApp.Api.Vehicle", "Vehicle")
                        .WithMany("VehicleAttributes")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehiclesApp.Api.VehicleAttributeValue", b =>
                {
                    b.HasOne("VehiclesApp.Api.AttributeValue", "AttributeValue")
                        .WithMany("VehicleAttributeValues")
                        .HasForeignKey("AttributeValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehiclesApp.Api.VehicleAttribute", "VehicleAttribute")
                        .WithMany("VehicleAttributeValues")
                        .HasForeignKey("VehicleAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeValue");

                    b.Navigation("VehicleAttribute");
                });

            modelBuilder.Entity("VehiclesApp.Api.VehicleModel", b =>
                {
                    b.HasOne("VehiclesApp.Api.VehicleMake", "VehicleMake")
                        .WithMany()
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("VehiclesApp.Api.Attribute", b =>
                {
                    b.Navigation("VehicleAttributes");
                });

            modelBuilder.Entity("VehiclesApp.Api.AttributeValue", b =>
                {
                    b.Navigation("VehicleAttributeValues");
                });

            modelBuilder.Entity("VehiclesApp.Api.Vehicle", b =>
                {
                    b.Navigation("VehicleAttributes");
                });

            modelBuilder.Entity("VehiclesApp.Api.VehicleAttribute", b =>
                {
                    b.Navigation("VehicleAttributeValues");
                });
#pragma warning restore 612, 618
        }
    }
}
