using System;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using projetIoT;
namespace projetIoT
{
    class HttpConnector
    {
        public static 
        HttpClient Client { get; set; } = new HttpClient();
        private static String BASE_URL ="http://iotcsharp.ma-soft.fr/RingApi/";
        public HttpConnector(){
            
        }
        public async Task ring(bool ringing){
            if(ringing)
                startRinging();
            else 
                stopRinging();
        }
        public async Task startRinging(){
            var url=BASE_URL+"ringingStart";
            var model=new RingModel();
            model.Ringing=true;
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await Client.PostAsync(url,data);
        }
          public async Task stopRinging(){
            var url=BASE_URL+"ringingEnd";
            var model=new RingModel();
            model.Ringing=false;
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await Client.PostAsync(url,data);
       

        }
    }
}