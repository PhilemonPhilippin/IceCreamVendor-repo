using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Service;

public class LogService : ILogService
{
    private readonly string _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private string _pathDirectory = string.Empty;
    private readonly ILogger<LogService> _logger;

    public LogService(ILogger<LogService> logger)
    {
        _logger = logger;
    }
    public bool LogSell(string flavour)
    {
        CreateLogDirectory();
        CreateLogFile("sells");
        bool isWritten = WriteLogs("sells", $"The vendor sells {flavour} ice cream at {DateTime.Now}");
        _logger.LogInformation("The vendor sells {flavour} ice cream at {time}", flavour, DateTime.Now);

        return isWritten;
    }

    public bool LogWarning(string choice)
    {
        CreateLogDirectory();
        CreateLogFile("warnings");
        bool isWritten = WriteLogs("warnings", $"Customer asked ice cream flavour : {choice} at {DateTime.Now}");
        _logger.LogWarning("Customer asked ice cream flavour : {choice} at {time}", choice, DateTime.Now);

        return isWritten;
    }
    private void CreateLogDirectory()
    {
        _pathDirectory = Path.Combine(_baseDirectory, "Logs");
        if (Directory.Exists(_pathDirectory) == false)
        {
            Directory.CreateDirectory(_pathDirectory);
        }
    }

    private bool CreateLogFile(string fileName)
    {
        bool isFileCreated = false;
        fileName += ".txt";
        string _pathFile = Path.Combine(_pathDirectory, fileName);

            if (File.Exists(_pathFile) == false)
            {
                using FileStream filestream = File.Create(_pathFile);
                isFileCreated = true;
            }
            else
            {
                isFileCreated = false;
            }

        return isFileCreated;
    }

    private bool WriteLogs(string fileName, string text)
    {
        fileName += ".txt";
        string _pathFile = Path.Combine(_pathDirectory, fileName);
        bool isFileWritten = false;

        if (File.Exists(_pathFile))
        {
            using TextWriter writer = new StreamWriter(_pathFile, true);

            writer.WriteLine(text);

            isFileWritten = true;
        }
        return isFileWritten;
    }

}
