﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeaBusiness_DAL;

#nullable disable

namespace TeaBusinessDAL.Migrations
{
    [DbContext(typeof(TeaBusinessDbContext))]
    [Migration("20230201174004_create")]
    partial class create
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StorageModelTeaModel", b =>
                {
                    b.Property<long>("StoragesStoringId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeasStoredId")
                        .HasColumnType("bigint");

                    b.HasKey("StoragesStoringId", "TeasStoredId");

                    b.HasIndex("TeasStoredId");

                    b.ToTable("StorageModelTeaModel");
                });

            modelBuilder.Entity("TeaBusiness_BLL.Contracts.Models.StorageModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Storage", (string)null);
                });

            modelBuilder.Entity("TeaBusiness_BLL.Contracts.Models.TeaModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tea", (string)null);
                });

            modelBuilder.Entity("StorageModelTeaModel", b =>
                {
                    b.HasOne("TeaBusiness_BLL.Contracts.Models.StorageModel", null)
                        .WithMany()
                        .HasForeignKey("StoragesStoringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeaBusiness_BLL.Contracts.Models.TeaModel", null)
                        .WithMany()
                        .HasForeignKey("TeasStoredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
