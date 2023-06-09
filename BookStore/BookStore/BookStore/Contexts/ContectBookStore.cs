using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.EFBookStore;
using System.Configuration;


namespace BookStore.Contexts
{
    public class ContectBookStore : DbContext
    {
        public ContectBookStore(string connection) : base(connection) { }
        public ContectBookStore() : base("DBConnection") { }

        public DbSet<ProdavecBook> prodavecBooks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountBook> DiscountBooks { get; set; }
        public DbSet<Basket> Baskets { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Book

            modelBuilder.Entity<Book>()
                .Property(d => d.DateOfublication)
                .HasColumnType("date");

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Title)
                .IsClustered(false)
                .IsUnique(true);

            modelBuilder.Entity<Book>()
                .Property(a => a.FIOAuthor)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(ph => ph.PublishingHouse)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .HasIndex(ph => ph.PublishingHouse)
                .IsClustered(false)
                .IsUnique(false);

            modelBuilder.Entity<Book>()
                .Property(b => b.NumberOfPages);

            modelBuilder.Entity<Book>()
                .Property(g => g.Genre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasIndex(g => g.Genre)
                .IsClustered(false)
                .IsUnique(false);

            modelBuilder.Entity<Book>()
                .Property(b => b.CostPrice)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(d => d.CostPrice)
                .HasColumnType("money");

            modelBuilder.Entity<Book>()
                .Property(b => b.PriceForSale)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(d => d.PriceForSale)
                .HasColumnType("money");

            base.OnModelCreating(modelBuilder);
            #endregion

            #region User

            modelBuilder.Entity<User>()
                .Property(b => b.FIO)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.Password)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.Role)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.Login)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(b => b.Login)
                .IsClustered(false)
                .IsUnique(true);

            #endregion

            #region ProdavecBook

            modelBuilder.Entity<ProdavecBook>()
                .HasRequired(de => de.User)
                .WithMany(d => d.ProdavecBooks)
                .HasForeignKey(de => de.UserId)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<ProdavecBook>()
                .HasRequired(de => de.Book)
                .WithMany(d => d.ProdavecBooks)
                .HasForeignKey(de => de.BookId)
                .WillCascadeOnDelete(true);

            #endregion

            #region Sale

            modelBuilder.Entity<Sale>()
                .HasRequired(de => de.Book)
                .WithMany(d => d.Sales)
                .HasForeignKey(de => de.BookId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Sale>()
                .Property(d => d.DateOfSale)
                .HasColumnType("date");

            #endregion

            #region Discount

            modelBuilder.Entity<Discount>()
                .Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Discount>()
                .HasIndex(b => b.Title)
                .IsClustered(false)
                .IsUnique(true);

            modelBuilder.Entity<Discount>()
                .Property(b => b.DiscountOfBook)
                .IsRequired();


            #endregion

            #region DiscountBook

            modelBuilder.Entity<DiscountBook>()
                .HasRequired(de => de.Book)
                .WithMany(d => d.DiscountBooks)
                .HasForeignKey(de => de.BookId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<DiscountBook>()
                .HasRequired(de => de.Discount)
                .WithMany(d => d.DiscountBooks)
                .HasForeignKey(de => de.DisscontId)
                .WillCascadeOnDelete(true);


            #endregion

            #region Basket

            modelBuilder.Entity<Basket>()
                .HasRequired(de => de.Book)
                .WithMany(d => d.Baskets)
                .HasForeignKey(de => de.BookId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Basket>()
                .HasRequired(de => de.User)
                .WithMany(d => d.Baskets)
                .HasForeignKey(de => de.UserId)
                .WillCascadeOnDelete(true);

            #endregion
        }
    }
}
