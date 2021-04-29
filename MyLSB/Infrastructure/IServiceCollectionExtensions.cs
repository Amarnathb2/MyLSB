using MyLSB.Repository;

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
            services.AddSingleton<NavigationRepository>();
            services.AddSingleton<LinkRepository>();
            services.AddSingleton<PageRepository>();
            services.AddSingleton<SettingsRepository>();
            services.AddSingleton<PartialsRepository>();
            services.AddSingleton<FeatureRepository>();
            services.AddSingleton<PanelRepository>();
            //services.AddSingleton<BlogPostRepository>();
            //services.AddSingleton<CategoryRepository>();
            //services.AddSingleton<ColumnRepository>();
            //services.AddSingleton<PersonRepository>();
            //services.AddSingleton<FAQRepository>();
            //services.AddSingleton<JsonTableRepository>();
            //services.AddSingleton<BannerRepository>();
            //services.AddSingleton<PropertyRepository>();
            //services.AddSingleton<CustomTableRepository>();
            //services.AddSingleton<NewsletterRepository>();
            //services.AddSingleton<MilestoneRepository>();
        }

        private static void AddViewComponentServices(IServiceCollection services)
        {
        }
    }
}
