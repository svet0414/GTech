using System;
using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class psu0221_1074251Context : DbContext
    {
        public psu0221_1074251Context() 
        {
        }

        public psu0221_1074251Context(DbContextOptions options)
            : base(options)
        {
        }
       
            
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorBookRelation> AuthorBookRelations { get; set; }
        public virtual DbSet<BaseMetadatum> BaseMetadata { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Ddc> Ddcs { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=hildur.ucn.dk;Database=psu0221_1074251;User Id=psu0221_1074251;Password=Password1!;");
                //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9EEFBAU\MSSQLSERVER01;Initial Catalog=test33;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("f_name");

                entity.Property(e => e.LName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("l_name");
            });

            modelBuilder.Entity<AuthorBookRelation>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId });

                entity.ToTable("author_book_relation");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorBookRelations)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__author_bo__autho__3A81B327");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorBookRelations)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__author_bo__book___3B75D760");
            });

            modelBuilder.Entity<BaseMetadatum>(entity =>
            {
                entity.ToTable("base_metadata");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.NumberOfCopies).HasColumnName("number_of_copies");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.BaseMetadata)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__base_metad__type__267ABA7A");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.HasIndex(e => e.Isbn13, "UQ__book__3BF79E02181D1F8C")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Ddcs).HasColumnName("ddcs");

                entity.Property(e => e.Isbn13)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("ISBN13");

                entity.Property(e => e.Language).HasColumnName("language");

                entity.Property(e => e.PageCount).HasColumnName("page_count");

                entity.Property(e => e.PublisherId).HasColumnName("publisher_id");

                entity.HasOne(d => d.DdcsNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Ddcs)
                    .HasConstraintName("FK__book__ddcs__35BCFE0A");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Book)
                    .HasForeignKey<Book>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__book__id__34C8D9D1");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__book__language__37A5467C");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK__book__publisher___36B12243");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.CardNumber)
                    .HasName("PK__card__1E6E0AF5207697DF");

                entity.ToTable("card");

                entity.Property(e => e.CardNumber).HasColumnName("card_number");

                entity.Property(e => e.DateExpire)
                    .HasColumnType("date")
                    .HasColumnName("date_expire");

                entity.Property(e => e.DateIssued)
                    .HasColumnType("date")
                    .HasColumnName("date_issued");

                entity.Property(e => e.MemberSsn).HasColumnName("member_ssn");

                entity.Property(e => e.Photo)
                    .HasColumnType("image")
                    .HasColumnName("photo");

                entity.HasOne(d => d.MemberSsnNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.MemberSsn)
                    .HasConstraintName("FK__card__member_ssn__45F365D3");
            });

            modelBuilder.Entity<Ddc>(entity =>
            {
                entity.HasKey(e => e.DdcsCode)
                    .HasName("PK__ddcs__85B763B90AD4ED18");

                entity.ToTable("ddcs");

                entity.Property(e => e.DdcsCode)
                    .ValueGeneratedNever()
                    .HasColumnName("ddcs_code");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Condition)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("condition");

                entity.Property(e => e.IsLoanable).HasColumnName("is_loanable");

                entity.Property(e => e.ItemMetadata).HasColumnName("item_metadata");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.HasOne(d => d.ItemMetadataNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemMetadata)
                    .HasConstraintName("FK__item__item_metad__29572725");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("item_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Language1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("language");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("loan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateDue)
                    .HasColumnType("date")
                    .HasColumnName("date_due");

                entity.Property(e => e.DateFinished)
                    .HasColumnType("date")
                    .HasColumnName("date_finished");

                entity.Property(e => e.DateLoaned)
                    .HasColumnType("date")
                    .HasColumnName("date_loaned");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.MemberSnn).HasColumnName("member_snn");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__loan__item_id__48CFD27E");

                entity.HasOne(d => d.MemberSnnNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.MemberSnn)
                    .HasConstraintName("FK__loan__member_snn__49C3F6B7");
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.ToTable("map");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Scale)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("scale");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Map)
                    .HasForeignKey<Map>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__map__id__3E52440B");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.Ssn)
                    .HasName("PK__member__DDDF0AE7832B4A4F");

                entity.ToTable("member");

                entity.Property(e => e.Ssn)
                    .ValueGeneratedNever()
                    .HasColumnName("ssn");

                entity.Property(e => e.CampusAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("campus_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("f_name");

                entity.Property(e => e.HomeAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("home_address");

                entity.Property(e => e.LName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("l_name");

                entity.Property(e => e.MemberType).HasColumnName("member_type");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.MemberTypeNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.MemberType)
                    .HasConstraintName("FK__member__member_t__4316F928");
            });

            modelBuilder.Entity<MemberType>(entity =>
            {
                entity.ToTable("member_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GracePeriod).HasColumnName("grace_period");

                entity.Property(e => e.LoanPeriod).HasColumnName("loan_period");

                entity.Property(e => e.MaximumLoans).HasColumnName("maximum_loans");

                entity.Property(e => e.NameOfMemberType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_of_member_type");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.HasKey(e => new { e.LoanId, e.DateSent })
                    .HasName("PK_reminder_loan");

                entity.ToTable("reminder");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.DateSent)
                    .HasColumnType("date")
                    .HasColumnName("date_sent");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__reminder__loan_i__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
