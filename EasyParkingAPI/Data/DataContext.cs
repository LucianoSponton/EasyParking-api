using EasyParkingAPI.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace EasyParkingAPI.Data
{
    public class DataContext : DbContext
    {
        private readonly SqlConnection _SqlConnection;
        private readonly string _connectionString;

        public DataContext()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            _connectionString = configuration.GetValue<string>("ConnectionString");
            _SqlConnection = new SqlConnection(_connectionString);
        }

        public DbSet<Estacionamiento> Estacionamientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_SqlConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //***************************************************************************************************
            // ESTACIONAMIENTO
            //***************************************************************************************************
            modelBuilder.Entity<Estacionamiento>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Estacionamiento>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(p => p.UserId);

        }


    }
}
