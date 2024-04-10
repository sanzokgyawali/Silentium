using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using AnonymousChat.EntityFrameworkCore.Seed.Host;
using AnonymousChat.EntityFrameworkCore.Seed.Tenants;

namespace AnonymousChat.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<AnonymousChatDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(AnonymousChatDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    //   var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    // contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
