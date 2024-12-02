using System;
using System.Collections.Generic;
using System.IO;
using sakin_csharp.EventLogCollector.Interfaces;
using sakin_csharp.EventLogCollector.Models;

namespace sakin_csharp.EventLogCollector.Services
{
    public class LinuxEventLogCollector : IEventLogCollector
    {
        private readonly string _logOutputPath;

        public LinuxEventLogCollector(string outputPath = null)
        {
            _logOutputPath = outputPath ?? Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), 
                "sakin_logs"
            );
            Directory.CreateDirectory(_logOutputPath);
        }

        public List<SystemEvent> CollectEvents(string logName = "/var/log/syslog")
        {
            var events = new List<SystemEvent>();

            try
            {
                var logLines = File.ReadAllLines(logName);
                foreach (var line in logLines)
                {
                    var systemEvent = ParseSyslogEntry(line);
                    if (systemEvent != null)
                    {
                        events.Add(systemEvent);
                        WriteEventToFile(systemEvent);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Linux event log toplama hatası: {ex.Message}");
            }

            return events;
        }

        private SystemEvent ParseSyslogEntry(string logLine)
        {
            // Basit bir syslog parse mekanizması
            // Gerçek dünya uygulamasında daha gelişmiş parsing gerekecektir
            try
            {
                var parts = logLine.Split(new[] { ' ' }, 6);
                return new SystemEvent
                {
                    Timestamp = DateTime.Parse(string.Join(" ", parts[0], parts[1], parts[2])),
                    Source = parts[3],
                    Message = parts[5],
                    EventType = "Info"  // Basitleştirilmiş
                };
            }
            catch
            {
                return null;
            }
        }

        public void WriteEventToFile(SystemEvent systemEvent)
        {
            string fileName = Path.Combine(_logOutputPath, 
                $"linux_event_log_{DateTime.Now:yyyyMMdd}.txt");

            string logEntry = $"{systemEvent.Timestamp} | " +
                              $"Source: {systemEvent.Source} | " +
                              $"Message: {systemEvent.Message}\n";

            File.AppendAllText(fileName, logEntry);
        }
    }
}