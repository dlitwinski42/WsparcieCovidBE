
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Data
{
    public class DataContext : DbContext
    {

        public DataContext([NotNull] DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Entrepreneur> Entrepreneurs { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SupportMethods> SupportMethods { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}