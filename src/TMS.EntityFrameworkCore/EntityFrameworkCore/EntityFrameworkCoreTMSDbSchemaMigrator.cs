using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TMS.Data;
using Volo.Abp.DependencyInjection;

namespace TMS.EntityFrameworkCore;

public class EntityFrameworkCoreTMSDbSchemaMigrator
    : ITMSDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTMSDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        await _serviceProvider
            .GetRequiredService<TMSDbContext>()
            .Database
            .MigrateAsync();
    }
}
