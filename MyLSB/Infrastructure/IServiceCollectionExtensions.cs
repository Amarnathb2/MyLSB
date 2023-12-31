﻿using MyLSB.Repository;

using Microsoft.Extensions.DependencyInjection;
using MyLSB.Infrastructure;

namespace MyLSB
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMyLSBServices(this IServiceCollection services)
        {
            AddViewComponentServices(services);

            AddRepositories(services);

            services.AddSingleton<RepositoryCacheHelper>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddSingleton<AlertRepository>();
            services.AddSingleton<BannerRepository>();
            services.AddSingleton<NavigationRepository>();
            services.AddSingleton<LinkRepository>();
            services.AddSingleton<PageRepository>();
            services.AddSingleton<SettingsRepository>();
            services.AddSingleton<PartialsRepository>();
            services.AddSingleton<FeatureRepository>();
            services.AddSingleton<PanelRepository>();
            services.AddSingleton<BlogPostLinkRepository>();
            services.AddSingleton<ProductsServicesRepository>();
            services.AddSingleton<ColumnRepository>();
            services.AddSingleton<EmployeeRepository>();
            services.AddSingleton<StatisticRepository>();
            services.AddSingleton<JsonTableRepository>();
        }

        private static void AddViewComponentServices(IServiceCollection services)
        {
        }
    }
}
