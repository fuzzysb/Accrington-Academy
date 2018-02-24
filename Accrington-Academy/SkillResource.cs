namespace AccringtonAcademy
{
    public class SkillResource
    {
        public string Language { get; set; }
        public string SkillName { get; set; }
        public string LaunchMessage { get; set; }
        public string HelpMessage { get; set; }
        public string StopMessage { get; set; }
        public string StandardReprompt { get; set; }

        public SkillResource(string language)
        {
            Language = language;
        }
    }
}