using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClimateTechRepairmentSystem.Models.Generated;

public partial class Database1Context : DbContext
{
    public Database1Context()
    {
    }

    public Database1Context(DbContextOptions<Database1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<RepairPart> RepairParts { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

    public virtual DbSet<TechType> TechTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=database1;User Id=Admin;Password=Adm1n;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comment");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.MasterId).HasColumnName("master_id");
            entity.Property(e => e.Message)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.RequestId).HasColumnName("request_id");

            entity.HasOne(d => d.Master).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comment_master");

            entity.HasOne(d => d.Request).WithMany(p => p.Comments)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comment_request");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.ToTable("master");

            entity.Property(e => e.MasterId).HasColumnName("master_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<RepairPart>(entity =>
        {
            entity.ToTable("repair_part");

            entity.Property(e => e.RepairPartId).HasColumnName("repair_part_id");
            entity.Property(e => e.RepairPart1)
                .IsUnicode(false)
                .HasColumnName("repair_part");
            entity.Property(e => e.RequestId).HasColumnName("request_id");

            entity.HasOne(d => d.Request).WithMany(p => p.RepairParts)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_repair_part_request");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("request");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateStarted).HasColumnName("date_started");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.MasterId).HasColumnName("master_id");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.ProblemDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("problem_description");
            entity.Property(e => e.RequestStatusId).HasColumnName("request_status_id");
            entity.Property(e => e.TechTypeId).HasColumnName("tech_type_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_request_client");

            entity.HasOne(d => d.Master).WithMany(p => p.Requests)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("FK_request_master");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_request_request_status");

            entity.HasOne(d => d.TechType).WithMany(p => p.Requests)
                .HasForeignKey(d => d.TechTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_request_tech_type");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.ToTable("request_status");

            entity.Property(e => e.RequestStatusId).HasColumnName("request_status_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TechType>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("tech_type");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Login)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
            entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_user_type");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("user_type");

            entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
