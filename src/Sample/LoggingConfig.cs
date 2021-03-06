﻿using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

class LoggingConfig
{
    public static void ConfigureLog4Net()
    {
        var layout = new PatternLayout
        {
            ConversionPattern = "%d [%t] %-5p %c [%x] - %m%n"
        };
        layout.ActivateOptions();
        var consoleAppender = new ColoredConsoleAppender
        {
            Threshold = Level.Debug,
            Layout = layout
        };
        consoleAppender.ActivateOptions();
        var appender = new RollingFileAppender
        {
            DatePattern = "yyyy-MM-dd'.txt'",
            RollingStyle = RollingFileAppender.RollingMode.Composite,
            MaxFileSize = 10 * 1024 * 1024,
            MaxSizeRollBackups = 10,
            LockingModel = new FileAppender.MinimalLock(),
            StaticLogFileName = false,
            File =  @"nsb_log_",
            Layout = layout,
            AppendToFile = true,
            Threshold = Level.Debug,
        };
        appender.ActivateOptions();

        BasicConfigurator.Configure(appender, consoleAppender);
    }
}