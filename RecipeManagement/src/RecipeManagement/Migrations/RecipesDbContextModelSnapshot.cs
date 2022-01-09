﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecipeManagement.Databases;

#nullable disable

namespace RecipeManagement.Migrations
{
    [DbContext(typeof(RecipesDbContext))]
    partial class RecipesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RecipeManagement.Domain.Recipes.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Directions")
                        .HasColumnType("text")
                        .HasColumnName("directions");

                    b.Property<string>("ImageLink")
                        .HasColumnType("text")
                        .HasColumnName("image_link");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("RecipeSourceLink")
                        .HasColumnType("text")
                        .HasColumnName("recipe_source_link");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_recipes");

                    b.ToTable("recipes", (string)null);
                });

            modelBuilder.Entity("RecipeManagement.Domain.RolePermissions.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("Permission")
                        .HasColumnType("text")
                        .HasColumnName("permission");

                    b.Property<string>("Role")
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("pk_role_permissions");

                    b.ToTable("role_permissions", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
