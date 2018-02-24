using System.Collections.Generic;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AccringtonAcademy
{
    public partial class Function
    {
        private string HomePage { get; set; }
        private AmazonDynamoDBClient Dbclient { get; set; }

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var log = context.Logger;
            log.LogLine("Skill Request Object:");
            log.LogLine(JsonConvert.SerializeObject(input));
            SkillResponse response = null;
            
            var allResources = GetAllResources(); //Gets all Messages/Language Strings
            var resource = allResources.Find(x => x.Language == input.Request.Locale); //Matches the Language Set with the locale in the request and uses that Language String
            try
            {
                if (HomePage == null)
                {
                    HomePage = GetHomePage().ToLower(); //Gets Result of the Homepage
                }
            }
            catch
            {
                HomePage = GetHomePage().ToLower(); //Gets Result of the Homepage
            }
            if (input.GetRequestType() == typeof(LaunchRequest))
            {
                log.LogLine(@"Default LaunchRequest made: Alexa, Launch Bite Me");
                var shouldExit = false;
                response = LaunchIntent(input, context, resource);
            }
            else if (input.GetRequestType() == typeof(IntentRequest))
            {
                var intentRequest = (IntentRequest)input.Request;
                var shouldExit = false;
                switch (intentRequest.Intent.Name)
                {
                    case "AMAZON.CancelIntent":
                        shouldExit = true;
                        response = CancelIntent(input, context, resource); //quit the game
                        break;

                    case "AMAZON.StopIntent":
                        shouldExit = true;
                        response = CancelIntent(input, context, resource); //quit the game
                        break;

                    case "AMAZON.NavigateHomeIntent":
                        shouldExit = true;
                        response = CancelIntent(input, context, resource); //quit the game
                        break;

                    case "AMAZON.HelpIntent":
                        log.LogLine("AMAZON.HelpIntent: send HelpMessage");
                        shouldExit = false;
                        response = HelpIntent(input, context, resource);
                        break;

                    case "TimeTableIntent":
                        log.LogLine("TimeTableIntent: Check response and give Week Number");
                        shouldExit = true;
                        response = TimeTableIntent(input, context, resource);
                        break; 
                
                    default:
                        //if alexa hears anthing that does not match any intent will return new retort.
                        log.LogLine("Unknown intent: " + intentRequest.Intent.Name);
                        shouldExit = true;
                        response = TimeTableIntent(input, context, resource);
                        break;
                }
            }
            return response; //returns the response recieved back from each intent function back to amazon
        }
    }
}
