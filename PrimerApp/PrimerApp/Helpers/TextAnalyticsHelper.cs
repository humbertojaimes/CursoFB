using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using analisis.Model;
using Newtonsoft.Json;

namespace PrimerApp.Helpers
{
    public static class TextAnalyticsHelper
    {
       
        public static async Task<ResultDocument>
        MakeKeyWordAnalysis(IEnumerable<RequestMessage> messages)
        {
            ResultDocument resultDocument = null;

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key"
                                                , "1a62f2876b9241f2bf840de102744575");

            HttpContent content = new StringContent
                (JsonConvert.SerializeObject( new RequestDocument { Messages = messages } ));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseMessage = await httpClient.PostAsync
                ("https://southcentralus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases"
                 , content);

            if(responseMessage.IsSuccessStatusCode)
            {

                string response = await responseMessage.Content.ReadAsStringAsync();

                resultDocument = JsonConvert.DeserializeObject<ResultDocument>
                                            (response);
            }

            return resultDocument;
        }      

    }
}
