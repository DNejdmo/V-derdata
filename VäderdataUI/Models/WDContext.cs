﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Väderdata.Models;

public class WDContext : DbContext

{
    private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WeatherKevinDanielDB;Integrated Security=True;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    DbSet<WeatherData> WeatherData { get; set; }
}
