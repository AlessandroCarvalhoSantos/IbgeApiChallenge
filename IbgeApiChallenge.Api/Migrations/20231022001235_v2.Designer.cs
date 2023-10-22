﻿// <auto-generated />
using System;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IbgeApiChallenge.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231022001235_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IbgeApiChallenge.Core.Contexts.StateContext.Entitties.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("acronym");

                    b.Property<string>("IbgeCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("ibge_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasAlternateKey("IbgeCode");

                    b.ToTable("states", (string)null);
                });

            modelBuilder.Entity("IbgeApiChallenge.Core.Contexts.UserContext.Entities.Locality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IbgeCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("ibge_code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.Property<Guid>("StateId")
                        .HasMaxLength(2)
                        .HasColumnType("uniqueidentifier ")
                        .HasColumnName("state_id");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("localities", (string)null);
                });

            modelBuilder.Entity("IbgeApiChallenge.Core.Contexts.UserContext.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("auth_roles", (string)null);
                });

            modelBuilder.Entity("IbgeApiChallenge.Core.Contexts.UserContext.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("given_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("auth_users", (string)null);
                });

            modelBuilder.Entity("auth_users_x_roles", b =>
                {
                    b.Property<Guid>("id_role")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("id_user")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id_role", "id_user");

                    b.HasIndex("id_user");

                    b.ToTable("auth_users_x_roles");
                });

            modelBuilder.Entity("IbgeApiChallenge.Core.Contexts.UserContext.Entities.Locality", b =>
                {
                    b.HasOne("IbgeApiChallenge.Core.Contexts.StateContext.Entitties.State", "State")
                        .WithMany("LocalityList")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("IbgeApiChallenge.Core.Contexts.UserContext.Entities.User", b =>
                {
                    b.OwnsOne("IbgeApiChallenge.Core.Contexts.UserContext.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("email");

                            b1.HasKey("UserId");

                            b1.ToTable("auth_users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("IbgeApiChallenge.Core.Contexts.UserContext.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Hash")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("password_hash");

                            b1.HasKey("UserId");

                            b1.ToTable("auth_users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("auth_users_x_roles", b =>
                {
                    b.HasOne("IbgeApiChallenge.Core.Contexts.UserContext.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("id_role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IbgeApiChallenge.Core.Contexts.UserContext.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IbgeApiChallenge.Core.Contexts.StateContext.Entitties.State", b =>
                {
                    b.Navigation("LocalityList");
                });
#pragma warning restore 612, 618
        }
    }
}
