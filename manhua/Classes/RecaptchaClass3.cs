using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace manhua.Classes
{
    public class RecaptchaClass3
    {
        [JsonProperty("success")] public string Success { get; set; }   // whether this request was a valid reCAPTCHA token for your site
        [JsonProperty("score")] public string score { get; set; }       // the score for this request (0.0 - 1.0)
        [JsonProperty("error-codes")] public List<string> ErrorCodes { get; set; }

        public static string Validate(string EncodedResponse)
        {
            var client = new WebClient();

            var PrivateKey = "6LemVIQUAAAAAGXrMjGLHb2NkcplFsOkhRi7ndPA";

            var GoogleReply = client.DownloadString(string.Format(
                "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey,
                EncodedResponse));

            var captchaResponse = JsonConvert.DeserializeObject<RecaptchaClass3>(GoogleReply);

            return captchaResponse.Success.ToLower();
        }
    }
}