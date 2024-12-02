using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using sakin_csharp.EventLogCollector.Interfaces;
using sakin_csharp.EventLogCollector.Models;

namespace sakin_csharp.EventLogCollector.Services
{
    public class WindowsEventLogCollector : IEventLogCollector
    {
        private readonly string _logOutputPath;

        public WindowsEventLogCollector(string outputPath = null)
        {
            _logOutputPath = outputPath ?? Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
                "sakin_logs"
            );
            Directory.CreateDirectory(_logOutputPath);
        }

        public List<SystemEvent> CollectEvents(string logName = "System")
        {
            var events = new List<SystemEvent>();

            try
            {
                EventLog log = new EventLog(logName);
                foreach (EventLogEntry entry in log.Entries)
                {
                    var systemEvent = new SystemEvent
                    {
                        Timestamp = entry.TimeGenerated,
                        Source = entry.Source,
                        EventType = entry.EntryType.ToString(),
                        Message = entry.Message,
                        EventId = entry.InstanceId
                    };

                    events.Add(systemEvent);
                    WriteEventToFile(systemEvent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Event log toplama hatası: {ex.Message}");
            }

            return events;
        }

        public void WriteEventToFile(SystemEvent systemEvent)
        {
            string fileName = Path.Combine(_logOutputPath, 
                $"event_log_{DateTime.Now:yyyyMMdd}.txt");

            string logEntry = $"{systemEvent.Timestamp} | " +
                              $"Source: {systemEvent.Source} | " +
                              $"Type: {systemEvent.EventType} | " +
                              $"Message: {systemEvent.Message}\n";

            File.AppendAllText(fileName, logEntry);
        }
    }
}