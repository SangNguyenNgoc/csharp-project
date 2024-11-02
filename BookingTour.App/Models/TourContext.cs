using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BookingTour.App.Models;

public partial class TourContext : DbContext
{
    public TourContext()
    {
    }

    public TourContext(DbContextOptions<TourContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Itinerary> Itineraries { get; set; }

    public virtual DbSet<ItineraryDetail> ItineraryDetails { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TourGuide> TourGuides { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=tour;user id=root;pooling=false", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("activity");

            entity.HasIndex(e => e.PlaceId, "activity_place_id_fk");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PlaceId)
                .HasColumnType("int(11)")
                .HasColumnName("place_id");

            entity.HasOne(d => d.Place).WithMany(p => p.Activities)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("activity_place_id_fk");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bill");

            entity.HasIndex(e => e.InvoiceIssuer, "bill_user_id_fk");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.InvoiceIssuer)
                .HasComment("người xuất hóa đơn")
                .HasColumnType("int(11)")
                .HasColumnName("invoice_issuer");
            entity.Property(e => e.TotalPassenger)
                .HasColumnType("int(11)")
                .HasColumnName("total_passenger");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");

            entity.HasOne(d => d.InvoiceIssuerNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.InvoiceIssuer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bill_user_id_fk");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("guides");

            entity.HasIndex(e => e.AccountId, "guides_user_id_fk");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AccountId)
                .HasColumnType("int(11)")
                .HasColumnName("account_id");
            entity.Property(e => e.Language)
                .HasMaxLength(255)
                .HasColumnName("language")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            entity.HasOne(d => d.Account).WithMany(p => p.Guides)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("guides_user_id_fk");
        });

        modelBuilder.Entity<Itinerary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("itinerary");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Capacity)
                .HasColumnType("int(11)")
                .HasColumnName("capacity");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.NumberOfDays)
                .HasComment("Số ngày đi ")
                .HasColumnType("int(11)")
                .HasColumnName("number_of_days");
            entity.Property(e => e.Vehicle)
                .HasColumnType("int(11)")
                .HasColumnName("vehicle");
        });

        modelBuilder.Entity<ItineraryDetail>(entity =>
        {
            entity.HasKey(e => new { e.ActivityId, e.TourInterfaceId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("itinerary_detail");

            entity.HasIndex(e => e.ServiceId, "itinerary_detail_service_id_fk");

            entity.HasIndex(e => e.TourInterfaceId, "tour_detail_tour_interface_id_fk");

            entity.Property(e => e.ActivityId)
                .HasColumnType("int(11)")
                .HasColumnName("activity_id");
            entity.Property(e => e.TourInterfaceId)
                .HasColumnType("int(11)")
                .HasColumnName("tour_interface_id");
            entity.Property(e => e.DayNumber)
                .HasComment("ngày thứ mấy trong tour")
                .HasColumnType("int(11)")
                .HasColumnName("day_number");
            entity.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasColumnName("end_time");
            entity.Property(e => e.ServiceId)
                .HasColumnType("int(11)")
                .HasColumnName("service_id");
            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasColumnName("start_time");

            entity.HasOne(d => d.Activity).WithMany(p => p.ItineraryDetails)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Itinerary_detail_activity_id_fk");

            entity.HasOne(d => d.Service).WithMany(p => p.ItineraryDetails)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("itinerary_detail_service_id_fk");

            entity.HasOne(d => d.TourInterface).WithMany(p => p.ItineraryDetails)
                .HasForeignKey(d => d.TourInterfaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tour_detail_tour_interface_id_fk");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("passenger")
                .HasCharSet("armscii8")
                .UseCollation("armscii8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Age)
                .HasColumnType("int(11)")
                .HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("place");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("service");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ticket");

            entity.HasIndex(e => e.TourId, "reservation_tour_instance_id_fk");

            entity.HasIndex(e => e.BillId, "ticket_bill_id_fk");

            entity.HasIndex(e => e.PassengerId, "ticket_passenger_id_fk");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BillId)
                .HasColumnType("int(11)")
                .HasColumnName("bill_id");
            entity.Property(e => e.PassengerId)
                .HasColumnType("int(11)")
                .HasColumnName("passenger_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TourId)
                .HasColumnType("int(11)")
                .HasColumnName("tour_id");
            entity.Property(e => e.Type)
                .HasColumnType("enum('adult','child(6-11)','child(<6)')")
                .HasColumnName("type");

            entity.HasOne(d => d.Bill).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("ticket_bill_id_fk");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_passenger_id_fk");

            entity.HasOne(d => d.Tour).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("reservation_tour_instance_id_fk");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tour");

            entity.HasIndex(e => e.ItineraryId, "tour_tour_interface_id_fk");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Capacity)
                .HasColumnType("int(11)")
                .HasColumnName("capacity");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.ItineraryId)
                .HasColumnType("int(11)")
                .HasColumnName("itinerary_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.RemainingSlots)
                .HasColumnType("int(11)")
                .HasColumnName("remaining_slots");

            entity.HasOne(d => d.Itinerary).WithMany(p => p.Tours)
                .HasForeignKey(d => d.ItineraryId)
                .HasConstraintName("tour_tour_interface_id_fk");
        });

        modelBuilder.Entity<TourGuide>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tour_guides");

            entity.HasIndex(e => e.TourId, "tour_guides_tour_instance_id_fk");

            entity.HasIndex(e => e.GuideId, "tour_guides_user_id_fk");

            entity.Property(e => e.GuideId)
                .HasColumnType("int(11)")
                .HasColumnName("guide_id");
            entity.Property(e => e.TourId)
                .HasColumnType("int(11)")
                .HasColumnName("tour_id");

            entity.HasOne(d => d.Guide).WithMany()
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("tour_guides_user_id_fk");

            entity.HasOne(d => d.Tour).WithMany()
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("tour_guides_tour_instance_id_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Age)
                .HasColumnType("int(11)")
                .HasColumnName("age");
            entity.Property(e => e.Description)
                .HasColumnType("int(11)")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasColumnType("int(11)")
                .HasColumnName("email");
            entity.Property(e => e.IsBlock).HasColumnName("is_block");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Password)
                .HasColumnType("int(11)")
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("int(11)")
                .HasColumnName("phone_number");
            entity.Property(e => e.Role)
                .HasColumnType("int(11)")
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
