using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

namespace AccringtonAcademy
{
    public partial class Function
    {
        public SkillResponse LaunchIntent(SkillRequest input, ILambdaContext context, SkillResource resource)
        {
            var log = context.Logger;
            log.LogLine("In Insult Intent");
            log.LogLine("Setting up Skill Response");
            var response = new SkillResponse
            {
                Response = new ResponseBody { ShouldEndSession = false, Reprompt = new Reprompt() }
            };


            //The device does not have a Scren so runs the following code block
            //Setting Welcome Speech Response
            IOutputSpeech innerSpeechResponse = new PlainTextOutputSpeech();
            IOutputSpeech innerSpeechResponseReprompt = new PlainTextOutputSpeech();

            if (resource != null)
            {
                ((PlainTextOutputSpeech)innerSpeechResponse).Text = resource.LaunchMessage;
                ((PlainTextOutputSpeech)innerSpeechResponseReprompt).Text = resource.StandardReprompt;

                //Setting Card Response
                var card = SetStandardCard(@"Accrington Academy", resource.LaunchMessage,
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