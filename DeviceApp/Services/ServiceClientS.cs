using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceApp.Services
{
    public class ServiceClientS
    {

        private static ServiceClient serviceClient;
        
        // Denna jag testar

        public ServiceClientS(string connectionstring)  // ctor
        {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionstring);
        }
        public async Task<CloudToDeviceMethodResult> InvokeMethod(string deviceId, string methodName, string payload)
        {

            var methodInvocation = new CloudToDeviceMethod(methodName); 
            methodInvocation.SetPayloadJson(payload);


            var response = await serviceClient.InvokeDeviceMethodAsync(deviceId, methodInvocation);

            return response;
        }

    }
}
