﻿// See https://aka.ms/new-console-template for more information
using Exceptions;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                .AddConsole();
        });

ILogger logger = loggerFactory.CreateLogger<Program>();

new StandardExceptionHandling(logger).ThrowEx();
new CustomExceptionHandling(logger).ThrowEx();