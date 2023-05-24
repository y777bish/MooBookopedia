using System.Windows;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using MooBookopedia.Data;

namespace MooBookopedia
{
    public partial class App
    {
        public App()
        {

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
        }
    }
}
