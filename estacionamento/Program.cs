using System.Data;
using MySql.Data.MySqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adicionar os serviços ao contêiner
        builder.Services.AddControllersWithViews();

        var connectionString = builder.Configuration.GetConnectionString("Default");

        // Configurar a conexão com o MySQL
        builder.Services.AddScoped<IDbConnection>(sp =>
        {
            return new MySqlConnection(connectionString);
        });

        var app = builder.Build();

        // Configurar o pipeline de solicitação HTTP
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}