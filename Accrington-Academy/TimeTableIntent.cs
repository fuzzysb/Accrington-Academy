using System.Globalization;
using System.Text.RegularExpressions;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

namespace AccringtonAcademy
{
    public partial class Function
    {
        public SkillResponse TimeTableIntent(SkillRequest input, ILambdaContext context, SkillResource resource)
        {
            var log = context.Logger;
            log.LogLine("In TimeTableIntent");
            log.LogLine("Setting up Skill Response");
            var response = new SkillResponse
            {
                Response = new ResponseBody {ShouldEndSession = true}
            };

            var week1Matches = (Regex.Matches(HomePage, "*Week 1*")).Count;
            var week2Matches = (Regex.Matches(HomePage, "*Week 2*")).Count;
            var resultText = "";
            if (week1Matches > week2Matches)
            {
                resultText = "This Week it is Week 1 Orange";
                
            }
            else if (week2Matches > week1Matches)
            {
                resultText = "This Week it is Week 2 Purple";
            }
            else
            {
                resultText = "I am Sorry i do not know what week it is, try again later";
            }

            //The device does not have a Scren so runs the following code block
            //Setting Welcome Speech Response
            IOutputSpeech innerSpeechResponse = new PlainTextOutputSpeech();
            IOutputSpeech innerSpeechResponseReprompt = new PlainTextOutputSpeech();

            if (resource != null)
            {
                ((PlainTextOutputSpeech) innerSpeechResponse).Text = resultText;

                //Setting Card Response
                var card = SetStandardCard( @"Accrington Academy TimeTable", resultText,
                    SetCardImage(
                        "https://raw.githubusercontent.com/fuzzysb/Accrington-Academy/master/Accrington-Academy-Small.png",
                        "https://raw.githubusercontent.com/fuzzysb/Accrington-Academy/master/Accrington-Academy-Large.png"));
                response.Response.Card = card;
            }
       
            response.Response.OutputSpeech = innerSpeechResponse;
            response.Response.Reprompt.OutputSpeech = innerSpeechResponseReprompt;
            response.Version = "1.0";
            log.LogLine("Skill Response Object...");
            log.LogLine(JsonConvert.SerializeObject(response));
            return response;
        }
    }
}