using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Amazon.Lambda.Core;

namespace AccringtonAcademy
{
    public partial class Function
    {
        public string GetHomePage()
        {
            var request =
                WebRequest.Create(
                    "https://accrington-academy.org/");
            var response = request.GetResponseAsync().Result;
            var stream = response.GetResponseStream();
            var streamreader = new StreamReader(stream ?? throw new InvalidOperationException());
            var result = streamreader.ReadToEnd();
            return result;
        }
    }
}