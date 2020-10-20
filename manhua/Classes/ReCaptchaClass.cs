using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Test.Classes
{
    //Recaptcha V2 code
    public class ReCaptchaClass
    {
        [JsonProperty("success")] public string Success { get; set; }

        [JsonProperty("error-codes")] public List<string> ErrorCodes { get; set; }

        public static string Validate(string EncodedResponse)
        {
            var client = new WebClient();

            var PrivateKey = "6LcaW4QUAAAAAAOQEHXE-p0uhoxIWkjMVxdfOrU_";

            var GoogleReply = client.DownloadString(string.Format(
                "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey,
                EncodedResponse));

            var captchaResponse = JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);

            return captchaResponse.Success.ToLower();
            
        }
    }
}