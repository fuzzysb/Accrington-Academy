using System.Globalization;
using System.Runtime.CompilerServices;
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
            int week1Matches;
            int week2Matches;
            try
            {
                week1Matches = (Regex.Matches(HomePage, ".*week 1.*")).Count;
                week2Matches = (Regex.Matches(HomePage, ".*week 2.*")).Count;
            }
            catch
            {
                week1Matches = 0;
                week2Matches = 0;
                //ignored
            }
            
            var resultText = "";
            try
            {
                if (week1Matches > week2Matches)
                {
                    log.LogLine("Week 1 Evaluated");
                    resultText = "This Week it is: Week 1 - Orange";

                }
                else if (week2Matches > week1Matches)
                {
                    log.LogLine("Week 1 Evaluated");
                    resultText = "This Week it is: Week 2 - Purple";
                }
                else
                {
                    log.LogLine("Cannot Evaluate the Week");
                    resultText = "I am Sorry i do not know what week it is, please try again later";
                }
            }
            catch
            {
                log.LogLine("Cannot Evaluate the Week");
                resultText = "I am Sorry i do not know what week it is, please try again later";
            }
            

            //The device does not have a Scren so runs the following code block
            //Setting Welcome Speech Response
            IOutputSpeech innerSpeechResponse = new PlainTextOutputSpeech();
           

            ((PlainTextOutputSpeech) innerSpeechResponse).Text = resultText;

            //Setting Card Response
            log.LogLine("Setting up the Card Response");
            var card = SetStandardCard( @"Accrington Academy TimeTable", resultText,
                SetCardImage(
                    "https://raw.githubusercontent.com/fuzzysb/Accrington-Academy/master/Accrington-Academy/AccringtonAcademy-Small.png",
                    "https://raw.githubusercontent.com/fuzzysb/Accrington-Academy/master/Accrington-Academy/AccringtonAcademy-Large.png"));
            response.Response.Card = card;
            
       
            response.Response.OutputSpeech = innerSpeechResponse;
            response.Version = "1.0";
            log.LogLine("Skill Response Object...");
            log.LogLine(JsonConvert.SerializeObject(response));
            return response;
        }
    }
}