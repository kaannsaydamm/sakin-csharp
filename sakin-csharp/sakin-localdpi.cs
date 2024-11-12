using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PacketDotNet;
using SharpPcap;

class NetworkPacketCapture
{
    // Dosya adları için interface adını temizleme fonksiyonu
    static string SanitizeName(string name)
    {
        return Regex.Replace(name, @"[<>:""\/\\|?*]", "_");
    }

    static async Task Main(string[] args)
    {
        try
        {
            // Tüm ağ arayüzlerini listele
            var devices = CaptureDeviceList.Instance;

            var tasks = new Task[devices.Count];

            for (int i = 0; i < devices.Count; i++)
            {
                var device = devices[i];
                tasks[i] = CapturePacketsAsync(device);
            }

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }

    static async Task CapturePacketsAsync(ICaptureDevice device)
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
                device.Open(DeviceMode.Promiscuous);

                // Paket yakalama event'i
                device.OnPacketArrival += (sender, e) =>
                {
                    var rawPacket = e.Packet;
                    var packet = Packet.Parse(rawPacket.Data);
                    var ipPacket = packet.Extract<IPPacket>();

                    if (ipPacket != null)
                    {
                        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - " +
                            $"Sender: {ipPacket.SourceAddress}, " +
                            $"Receiver: {ipPacket.DestinationAddress}, " +
                            $"Protocol: {ipPacket.Protocol}";

                        Console.WriteLine(logMessage);
                        logWriter.WriteLine(logMessage);
                        logWriter.Flush();
                    }
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
    }
}