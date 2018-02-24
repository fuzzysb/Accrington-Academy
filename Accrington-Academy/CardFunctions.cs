using Alexa.NET.Response;

namespace AccringtonAcademy
{
    public partial class Function
    {
        public CardImage SetCardImage(string smallImage, string largeImage)
        {
            CardImage image = new CardImage { LargeImageUrl = largeImage, SmallImageUrl = smallImage };
            return image;
        }

        public StandardCard SetStandardCard(string title, string content, CardImage images)
        {
            StandardCard card = new StandardCard { Title = title, Content = content, Image = images };
            return card;
        }
    }
}