using DeviceApp.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeviceApp.Services
{
    public class DeviceService
    {
        
        private static int _timeInterval = 5;
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string url = $"http://api.openweathermap.org/data/2.5/weather?q=%C3%96rebro&appid=b9f2df37033f5febf912e841800f475a&units=metric&cnt=6";
        


        public static async Task<MethodResponse> SetTimeInterval(MethodRequest methodRequest , object userContext)
        {
            var payload = Encoding.UTF8.GetString(methodRequest.Data).Replace("\"", "");

            if (Int32.TryParse(payload, out _timeInterval))
            {

                Console.WriteLine($"Interval set to: {_timeInterval} seconds.");

                // { "result": "Executed direct method: SetTelemetryInterval" }
                string json = "{\"result\": \"Executed direct method: " + methodRequest.Name + "\"}";
                return await Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(json), 200));
            }
            else
            {
                string json = "{\"result\": \"Method not implemented\"}";
                return await Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(json), 501)); // eller 400

            }

        }

        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
           while (true)
           {
                try
                {
                    var response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = JsonConvert.DeserializeObject<TemperaturModel.Root>(await response.Content.ReadAsStringAsync());

                        var data = JsonConvert.SerializeObject(json);


                        var payload = new Message(Encoding.UTF8.GetBytes(data));
                        await deviceClient.SendEventAsync(payload);

                        Console.WriteLine(data);
                        await Task.Delay(_timeInterval * 1000);
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong! {ex.Message}");
                }
           }
        }
    }
}
