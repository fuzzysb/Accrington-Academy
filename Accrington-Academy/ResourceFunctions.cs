using System.Collections.Generic;

namespace AccringtonAcademy
{
    public partial class Function
    {
        public List<SkillResource> GetAllResources()
        {
            List<SkillResource> resources = new List<SkillResource>();

            SkillResource enGbResource = new SkillResource("en-GB")
            {
                SkillName = "Accrington Academy",
                HelpMessage =
                    "You can ask which week it is, and alexa will tell you if it is week 1 or week 2, or you can say Stop or Cancel to exit this skill",
                LaunchMessage =
                    "Welcome to Accrington Academy, do you want to know what week it is?",
                StopMessage =
                    "Goodbye, have a good day at school.",
                StandardReprompt =
                    "do you want to know what week it is?"
            };
            resources.Add(enGbResource);

            SkillResource enUsResource = new SkillResource("en-US")
            {
                SkillName = "Accrington Academy",
                HelpMessage =
                    "You can ask which week it is, and alexa will tell you if it is week 1 or week 2, or you can say Stop or Cancel to exit this skill",
                LaunchMessage =
                    "Welcome to Accrington Academy, do you want to know what week it is?",
                StopMessage =
                    "Goodbye, have a good day at school.",
                StandardReprompt =
                    "do you want to know what week it is?"
            };
            resources.Add(enUsResource);

            SkillResource enCaResource = new SkillResource("en-CA")
            {
                SkillName = "Accrington Academy",
                HelpMessage =
                    "You can ask which week it is, and alexa will tell you if it is week 1 or week 2, or you can say Stop or Cancel to exit this skill",
                LaunchMessage =
                    "Welcome to Accrington Academy, do you want to know what week it is?",
                StopMessage =
                    "Goodbye, have a good day at school.",
                StandardReprompt =
                    "do you want to know what week it is?"
            };
            resources.Add(enCaResource);

            SkillResource enAuResource = new SkillResource("en-AU")
            {
                SkillName = "Accrington Academy",
                HelpMessage =
                    "You can ask which week it is, and alexa will tell you if it is week 1 or week 2, or you can say Stop or Cancel to exit this skill",
                LaunchMessage =
                    "Welcome to Accrington Academy, do you want to know what week it is?",
                StopMessage =
                    "Goodbye, have a good day at school.",
                StandardReprompt =
                    "do you want to know what week it is?"
            };
            resources.Add(enAuResource);

            SkillResource enInResource = new SkillResource("en-IN")
            {
                SkillName = "Accrington Academy",
                HelpMessage =
                    "You can ask which week it is, and alexa will tell you if it is week 1 or week 2, or you can say Stop or Cancel to exit this skill",
                LaunchMessage =
                    "Welcome to Accrington Academy, do you want to know what week it is?",
                StopMessage =
                    "Goodbye, have a good day at school.",
                StandardReprompt =
                    "do you want to know what week it is?"
            };
            resources.Add(enInResource);

            return resources;
        }
    }
}