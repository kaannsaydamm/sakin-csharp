using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using Microsoft.EntityFrameworkCore;
using sakin_csharp.Data;
using sakin_csharp.Models;
using sakin_csharp.Services;

class NetworkPacketCapture
{
    // Dosya adları için interface adını temizleme fonksiyonu1
    static string SanitizeName(string name)
    {
        return Regex.Replace(name, @"[<>:""/\\|?*]", "_");
    }

    public static async Task CapturePacketsAsync(ICaptureDevice device)
    {
        try
        {
            // Interface adını temizle
            string sanitizedName = SanitizeName(device.Name);

            // Log dosyası oluştur
            string logFilePath = Path.Combine(
                Directory.GetCurrentDirectory(), 
                $"network_packets_{sanitizedName}.log"
            );

            using (var logWriter = new StreamWriter(logFilePath, true))
            {
                // Cihazı aç
                device.Open(DeviceModes.Promiscuous);

                var optionsBuilder = new DbContextOptionsBuilder<SakinDbContext>();
                optionsBuilder.UseSqlServer("YourConnectionStringHere");
                var context = new SakinDbContext(optionsBuilder.Options);
                var service = new NetworkPacketService(context);

                // Paket yakalama event'i
                device.OnPacketArrival += (sender, e) =>
                {
                    var rawPacket = e.GetPacket(); // RawPacket'i al
                    Task.Run(async () =>
                    {
                        var packet = PacketDotNet.Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data); // Paket verisini çöz

                        var ipPacket = packet.Extract<PacketDotNet.IPPacket>();

                        if (ipPacket != null)
                        {
                            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - " +
                                $"Sender: {ipPacket.SourceAddress}, " +
                                $"Receiver: {ipPacket.DestinationAddress}, " +
                                $"Protocol: {ipPacket.Protocol}, " +
                                $"Length: {ipPacket.PayloadData.Length}";

                            Console.WriteLine(logMessage);
                            logWriter.WriteLine(logMessage);
                            logWriter.Flush();

                            var dbPacket = new NetworkPacket
                            {
                                Timestamp = DateTime.Now,
                                SourceAddress = ipPacket.SourceAddress.ToString(),
                                DestinationAddress = ipPacket.DestinationAddress.ToString(),
                                Protocol = ipPacket.Protocol.ToString(),
                                Length = ipPacket.PayloadData.Length
                            };

                            await service.AddPacketAsync(dbPacket);
                        }
                    });
                };

                // Yakalamayı başlat
                device.StartCapture();

                // Sonsuz yakalama için bekle
                await Task.Delay(System.Threading.Timeout.Infinite);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Interface {device.Name} için hata: {ex.Message}");
        }
        finally
        {
            device.StopCapture();
            device.Close();
        }
    }
}