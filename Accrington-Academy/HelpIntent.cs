using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

namespace AccringtonAcademy
{
    public partial class Function
    {
        public SkillResponse HelpIntent(SkillRequest input, ILambdaContext context, SkillResource resource)
        {
            var response = new SkillResponse
            {
                Response = new ResponseBody {ShouldEndSession = false, Reprompt = new Reprompt()}
            };
            var log = context.Logger;

            
            //Setting Speech Response
            IOutputSpeech innerSpeechResponse = new PlainTextOutputSpeech();
            IOutputSpeech innerSpeechResponseReprompt = new PlainTextOutputSpeech();
            if (resource != null)
            {
                //Set Speech Response
                ((PlainTextOutputSpeech) innerSpeechResponse).Text = resource.HelpMessage;
                //Set Reprompt Response
                ((PlainTextOutputSpeech) innerSpeechResponseReprompt).Text =
                    resource.StandardReprompt;

                //Setting Card Response
                var card = SetStandardCard("Accrington Academy Help", resource.HelpMessage,
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
            return response; //return the skill response back to the main function
        }
    }
}