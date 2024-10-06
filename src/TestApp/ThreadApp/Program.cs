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
    var testVar = forecast.Rob([2, 1, 1, 2]);
    //var testVar = forecast.MinimumTotal([[2], [3, 4], [6, 5, 7], [4, 1, 8, 3]]);
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
    public int Rob(int[] nums)
    {
        var curMax = 0;
        var prevMax = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int temp = curMax;
            curMax = Math.Max(prevMax + nums[i], curMax);
            prevMax = temp;
        }
        return curMax;
    }
    public int MajorityElement(int[] nums)
    {
        var test = nums.GroupBy(x => x);
        var testTwo = test.First(x => x.Count() == test.Max(x => x.Count())).Key;
        return 0;
    }

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

    public bool WordBreak(string s, IList<string> wordDict)
    {
        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true;
        int max_len = 0;
        foreach (string word in wordDict)
        {
            max_len = Math.Max(max_len, word.Length);
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = i - 1; j >= Math.Max(i - max_len - 1, 0); j--)
            {
                if (dp[j] && wordDict.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n];
    }

    public int SingleNumber(int[] nums)
    {
        var test = nums.GroupBy(x => x);
        int testTwo = test.Where(c => c.Count() == 1).Select(x => x.Key).FirstOrDefault();
        return 0;
    }

    public bool IsPalindrome(string s)
    {
        var leftIndex = 0;
        var rightIndex = s.Length - 1;

        while (leftIndex < rightIndex)
        {
            if (Char.IsLetterOrDigit(s[leftIndex]))
            {
                if (Char.IsLetterOrDigit(s[rightIndex]))
                {
                    if (Char.ToLower(s[leftIndex]) == Char.ToLower(s[rightIndex]))
                    {
                        leftIndex++;
                        rightIndex--;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    rightIndex--;
                }
            }
            else
            {
                leftIndex++;
            }
        }
        return false;
    }


    //[2]  
    //[5, 6], 
    //[11, 5, 7]   6
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        for (int i = 0; i < triangle.Count - 1; i++)
        {
            var curRowValue = 0;
            for (int j = 0; j < triangle[i].Count; j++)
            {
                if(j == 0) 
                { 
                    triangle[i + 1][j] += triangle[i][j]; 
                }
                else 
                {
                    triangle[i + 1][j] = Math.Min(curRowValue + triangle[i][j], triangle[i + 1][j]);
                }

                curRowValue = triangle[i + 1][j + 1];
                triangle[i + 1][j + 1] += triangle[i][j];
            }
        }
        return triangle[^1].Min();
    }

    public IList<int> GetRow(int rowIndex)
    {
        if (rowIndex == 0) return new List<int>() { 1 };
        var prevRow = new List<int>() { 1 };
        for (int i = 0; i < rowIndex; i++)
        {
            var curRow = new List<int>() { 1 };
            for (int j = 1; j <= i; j++)
            {
                curRow.Add(prevRow[j - 1] + prevRow[j]);
            }
            curRow.Add(1);
            prevRow = curRow;
        }
        return prevRow;
    }

    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>();
        if (numRows == 0) return result;
        result.Add(new List<int>() { 1 });
        for (int i = 1; i < numRows; i++)
        {
            var curRow = new List<int>() {1};
            for (int j = 1; j < i; j++)
            {
                curRow.Add(result[i-1][j - 1] + result[i-1][j]);
            }
            curRow.Add(1);
            result.Add(curRow);
        }
        return result;

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
