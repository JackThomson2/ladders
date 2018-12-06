﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ladders.Models;

namespace ladders.Migrations
{
    [DbContext(typeof(LaddersContext))]
    [Migration("20181205211026_LadderName")]
    partial class LadderName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ladders.Models.LadderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LadderModel");
                });

            modelBuilder.Entity("ladders.Models.ProfileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Availability")
                        .IsRequired();

                    b.Property<int>("CurrentLadder");

                    b.Property<int?>("LadderModelId");

                    b.Property<int?>("LadderModelId1");

                    b.Property<string>("Name");

                    b.Property<string>("PreferredLocation")
                        .IsRequired();

                    b.Property<bool>("Suspended");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LadderModelId");

                    b.HasIndex("LadderModelId1");

                    b.ToTable("ProfileModel");
                });

            modelBuilder.Entity("ladders.Models.Ranking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LadderModelId");

                    b.HasKey("Id");

                    b.HasIndex("LadderModelId");

                    b.ToTable("Ranking");
                });

            modelBuilder.Entity("ladders.Models.ProfileModel", b =>
                {
                    b.HasOne("ladders.Models.LadderModel")
                        .WithMany("ApprovalUsersList")
                        .HasForeignKey("LadderModelId");

                    b.HasOne("ladders.Models.LadderModel")
                        .WithMany("MemberList")
                        .HasForeignKey("LadderModelId1");
                });

            modelBuilder.Entity("ladders.Models.Ranking", b =>
                {
                    b.HasOne("ladders.Models.LadderModel")
                        .WithMany("CurrentRankings")
                        .HasForeignKey("LadderModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
