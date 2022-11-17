using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ADONETExample.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ADONETSAMPLE> ADONETSAMPLEs { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADONETSAMPLE>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<ADONETSAMPLE>()
                .Property(e => e.Region)
                .IsFixedLength();

            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasOptional(e => e.Genre1)
                .WithRequired(e => e.Genre2);

            modelBuilder.Entity<Track>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);
        }
    }
}
