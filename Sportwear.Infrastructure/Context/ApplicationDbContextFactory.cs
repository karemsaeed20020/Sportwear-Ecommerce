using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportwear.Infrastructure.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // تحميل الإعدادات من appsettings.json في مشروع البدء (Sportswear.Api)
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Sportswear.Api");  // هذا يفترض أن المشاريع في نفس المجلد الأب؛ قم بتعديل إذا لزم الأمر

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // This extension method is in Microsoft.Extensions.Configuration.FileExtensions
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true)  // إذا كان لديك إعدادات تطوير
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = configuration.GetConnectionString("cs");

            builder.UseSqlServer(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
