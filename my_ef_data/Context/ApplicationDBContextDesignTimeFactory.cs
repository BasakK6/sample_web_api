using System;
using Microsoft.EntityFrameworkCore.Design;
using my_ef_data.Context;

namespace my_sample_data.Context
{
    //Created for:
    //Unable to create an object of type 'ApplicationDBContext'. For the different patterns supported at design time
    //When running "dotnet ef migrations add initialMigration"
    public class ApplicationDBContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var context = new ApplicationDbContext();

            return context;
        }
    }
}

