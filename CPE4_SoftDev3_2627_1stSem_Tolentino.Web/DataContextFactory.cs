using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>

{

    public DataContext CreateDbContext(string[] args)

    {

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        // Replace with your real connection string (or read from env var)
        var conn = Environment.GetEnvironmentVariable("CONNECTION_STRING")

                   ?? "Server=(localdb)\\mssqllocaldb;Database=CPE4App;Trusted_Connection=True;";

        optionsBuilder.UseSqlServer(conn);


        return new DataContext(optionsBuilder.Options);

    }

}