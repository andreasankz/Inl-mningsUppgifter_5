using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeviceApp.Tests
{

    public class DeviceServiceTest
    {
        [Fact]
        public async Task CheckHttpResponse_ShouldCheckForWorkingHttp() // integration test
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=%C3%96rebro&appid=b9f2df37033f5febf912e841800f475a&units=metric&cnt=6");


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
