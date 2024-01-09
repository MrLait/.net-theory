var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
var forecastOne = new WeatherForecast();
forecastOne.GetCurrThreadId("ProgramCS thread");
app.MapGet("/weatherforecast", () =>
{
    var forecast = new WeatherForecast();
    forecast.GetCurrThreadId("MapGet thread");
    var test = "asd";
    forecast.TestAsync(test);
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
forecastOne.GetCurrThreadId("ProgramCS thread");
app.Run();


public class WeatherForecast
{
    public async Task TestAsync(string test)
    {
        test = "a";
        for (int i = 0; i < 20; i++)
        {
            GetCurrThreadId($"Method {i} thread");
            await SomeAsyncJob();
            GetCurrThreadId($"Method {i} thread");
            await SomeAsyncJob();
            GetCurrThreadId($"Method {i} thread");
            await SomeAsyncJob();
            GetCurrThreadId($"Method {i} thread");
            await SomeAsyncJob();
            GetCurrThreadId($"Method {i} thread");
            await SomeAsyncJob();
            GetCurrThreadId($"Method {i} thread");
            await SomeAsyncJob();
        }

        VoidTask();
    }

    public void GetCurrThreadId(string source) =>
        System.Diagnostics.Debug.WriteLine($"{source}:{Thread.CurrentThread.ManagedThreadId}");

    private async void VoidTask()
    {

    }

    private async Task SomeAsyncJob()
    {
        var random = new Random(1).Next(1, 1000);
        await Task.Delay(random);
        GetCurrThreadId($"SomeAsyncJob");
        var secondRandom = new Random(1).Next(1, 1000);
        await Task.Delay(secondRandom);
        GetCurrThreadId($"SomeAsyncJob");

    }
}
