using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pustok.Core.Entities.Common;
using Pustok.DataAccess.Context;

namespace Pustok.DataAccess.Interceptors
{
    public class BaseAuditableInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditTable(eventData);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditTable(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void UpdateAuditTable(DbContextEventData eventData)
        {
            if (eventData.Context is AppDbContext appDbContext)
            {
                var entities = appDbContext.ChangeTracker.Entries<BaseAuditableEntity>().ToList();

                foreach (var entry in entities)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedDate = DateTime.UtcNow;
                            entry.Entity.CreatedBy = "Admin user";
                            break;
                        case EntityState.Modified:
                            entry.Entity.UpdatedDate = DateTime.UtcNow;
                            entry.Entity.UpdatedBy = "Admin user";
                            break;
                        case EntityState.Deleted:
                            entry.Entity.DeletedDate = DateTime.UtcNow;
                            entry.Entity.DeletedBy = "Admin user";
                            entry.Entity.IsDeleted = true;
                            entry.State = EntityState.Modified;
                            break;

                    }


                }

            }
        }

    }
}
