﻿using System;

namespace BlazorEF.FunctionApp1.Entities;

public class WeatherForecast
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string Summary { get; set; }
}