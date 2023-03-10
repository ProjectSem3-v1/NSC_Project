// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSC_Project.Data;

#nullable disable

namespace NSCProject.Migrations
{
    [DbContext(typeof(NSC_ProjectContext))]
    [Migration("20230108173124_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NSC_Project.Models.AirlineCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirlineCompany");
                });

            modelBuilder.Entity("NSC_Project.Models.AirportFrom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirportFrom");
                });

            modelBuilder.Entity("NSC_Project.Models.AirportTo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirportTo");
                });

            modelBuilder.Entity("NSC_Project.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("NSC_Project.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("NSC_Project.Models.Fare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int>("TicketClassId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketClassId");

                    b.HasIndex("TripId");

                    b.ToTable("Fare");
                });

            modelBuilder.Entity("NSC_Project.Models.FlightRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AirportFromId")
                        .HasColumnType("int");

                    b.Property<int>("AirportToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirportFromId");

                    b.HasIndex("AirportToId");

                    b.ToTable("FlightRoute");
                });

            modelBuilder.Entity("NSC_Project.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plane");
                });

            modelBuilder.Entity("NSC_Project.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("NSC_Project.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FareId")
                        .HasColumnType("int");

                    b.Property<bool>("Solded")
                        .HasColumnType("bit");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FareId");

                    b.HasIndex("TripId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("NSC_Project.Models.TicketClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketClass");
                });

            modelBuilder.Entity("NSC_Project.Models.TicketDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketDetail");
                });

            modelBuilder.Entity("NSC_Project.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AirlineCompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightRouteId")
                        .HasColumnType("int");

                    b.Property<double>("FlightTime")
                        .HasColumnType("float");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirlineCompanyId");

                    b.HasIndex("FlightRouteId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("NSC_Project.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NSC_Project.Models.Bill", b =>
                {
                    b.HasOne("NSC_Project.Models.Customer", null)
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId");

                    b.HasOne("NSC_Project.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NSC_Project.Models.Fare", b =>
                {
                    b.HasOne("NSC_Project.Models.TicketClass", "TicketClass")
                        .WithMany("Fares")
                        .HasForeignKey("TicketClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_Project.Models.Trip", "Trip")
                        .WithMany("Fares")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TicketClass");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("NSC_Project.Models.FlightRoute", b =>
                {
                    b.HasOne("NSC_Project.Models.AirportFrom", "AirportFrom")
                        .WithMany()
                        .HasForeignKey("AirportFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_Project.Models.AirportTo", "AirportTo")
                        .WithMany()
                        .HasForeignKey("AirportToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AirportFrom");

                    b.Navigation("AirportTo");
                });

            modelBuilder.Entity("NSC_Project.Models.Ticket", b =>
                {
                    b.HasOne("NSC_Project.Models.Fare", "Fare")
                        .WithMany("Tickets")
                        .HasForeignKey("FareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_Project.Models.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fare");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("NSC_Project.Models.TicketDetail", b =>
                {
                    b.HasOne("NSC_Project.Models.Bill", "Bill")
                        .WithMany("TicketDetails")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_Project.Models.Customer", "Customer")
                        .WithMany("TicketDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_Project.Models.Ticket", "Ticket")
                        .WithMany("TicketDetails")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Customer");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("NSC_Project.Models.Trip", b =>
                {
                    b.HasOne("NSC_Project.Models.AirlineCompany", "AirlineCompany")
                        .WithMany("Trips")
                        .HasForeignKey("AirlineCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_Project.Models.FlightRoute", "FlightRoute")
                        .WithMany("Trips")
                        .HasForeignKey("FlightRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_Project.Models.Plane", "Plane")
                        .WithMany("Trips")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AirlineCompany");

                    b.Navigation("FlightRoute");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("NSC_Project.Models.User", b =>
                {
                    b.HasOne("NSC_Project.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NSC_Project.Models.AirlineCompany", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("NSC_Project.Models.Bill", b =>
                {
                    b.Navigation("TicketDetails");
                });

            modelBuilder.Entity("NSC_Project.Models.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("TicketDetails");
                });

            modelBuilder.Entity("NSC_Project.Models.Fare", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("NSC_Project.Models.FlightRoute", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("NSC_Project.Models.Plane", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("NSC_Project.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NSC_Project.Models.Ticket", b =>
                {
                    b.Navigation("TicketDetails");
                });

            modelBuilder.Entity("NSC_Project.Models.TicketClass", b =>
                {
                    b.Navigation("Fares");
                });

            modelBuilder.Entity("NSC_Project.Models.Trip", b =>
                {
                    b.Navigation("Fares");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
