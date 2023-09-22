namespace OpenApiSample;

public class NewWeatherForecast
{
    public DateOnly NewDate { get; init; }

    public int TemperatureC { get; init; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? NewSummary { get; init; }
}