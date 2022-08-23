using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TMS.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class TMSDbContext :
    AbpDbContext<TMSDbContext>
{
    #region Entities from the modules
    public DbSet<Company> Companys { get; set; }
    #endregion

    public TMSDbContext(DbContextOptions<TMSDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();

    }
}
