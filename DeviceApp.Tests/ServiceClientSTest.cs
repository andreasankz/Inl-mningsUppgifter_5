using DeviceApp.Services;
using Xunit;


namespace DeviceApp.Tests
{
    public class ServiceClientSTest
    {
        [Theory]
        [InlineData("uppgifter5","SetTimeInterval", "10", "200")]
        [InlineData("uppgifter5","TimeInterval", "10", "501")]
        public void SetTimeInterval_ShouldCheckForWorkingServiceClientMethod(string deviceId, string methodName, string payload, string expected)
        {

            var service = new ServiceClientS("HostName=ec-win20-iothuben.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=B3ksnn30ICZhsaxdyS0qjB8Encs9MU/eVn4GzAS2HMY=");

            var response = service.InvokeMethod(deviceId, methodName, payload);


            Assert.Equal(expected, response.Result.Status.ToString());
            
        }
    }

}   
