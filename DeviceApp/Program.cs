using Microsoft.Azure.Devices.Client;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using DeviceApp.Services;

namespace DeviceApp
{
    class Program
    {
        private static DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=ec-win20-iothuben.azure-devices.net;DeviceId=uppgifter5;SharedAccessKey=sZMuPZc1B//BpkXukVldnkIeP92S5mSycyld1W0EewY=", TransportType.Mqtt);
        static void Main(string[] args)
        {

            deviceClient.SetMethodHandlerAsync("SetTimeInterval", DeviceService.SetTimeInterval, null).Wait();

            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();

            Console.ReadLine();
        }
    }
}
