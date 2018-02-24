using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

namespace AccringtonAcademy
{
    public partial class Function
    {
        public SkillResponse CancelIntent(SkillRequest input, ILambdaContext context, SkillResource resource)
        {
            var log = context.Logger;
            SkillResponse
                response = new SkillResponse
                {
                    Response = new ResponseBody {ShouldEndSession = true}
                }; //sets up the skill speech response format


            //Setting Speech Response
            IOutputSpeech innerSpeechResponse = new PlainTextOutputSpeech();
            if (resource != null)
            {
                //Setting Speech Response
                ((PlainTextOutputSpeech) innerSpeechResponse).Text = resource.StopMessage;
                // Setting App Card
                var card = SetStandardCard("GoodBye", resource.StopMessage,
                    SetCardImage(
                        "https://raw.githubusercontent.com/fuzzysb/Accrington-Academy/master/Accrington-Academy/AccringtonAcademy-Small.png",
                        "https://raw.githubusercontent.com/fuzzysb/Accrington-Academy/master/Accrington-Academy/AccringtonAcademy-Large.png"));
                response.Response.Card = card;
            }

            //Add Speech
            response.Response.OutputSpeech = innerSpeechResponse;
            response.Version = "1.0";
            log.LogLine("Skill Response Object...");
            log.LogLine(JsonConvert.SerializeObject(response));
            return response;
        }
    }
}