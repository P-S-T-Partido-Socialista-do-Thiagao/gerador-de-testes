namespace GeradorDeTestes.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEntityFrameworkConfig(builder.Configuration);
            var app = builder.Build();

            app.Run();
        }
    }
}
