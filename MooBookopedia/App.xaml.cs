using System.Windows;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using MooBookopedia.Data;
using MooBookopedia.Models;

namespace MooBookopedia
{
    public partial class App
    {
        public App()
        {

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DataBaseAccess>();
        }
    }
}
