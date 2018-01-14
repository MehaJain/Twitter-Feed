namespace TwitterFeederApp.Library
{
    using System.Collections.Generic;
    using System.Linq;

    public class TweetsDetails
    {
        public List<TwitterMedia> Media { get; set; }

        public List<TwitterUrl> Urls { get; set; }

        public TwitterMedia DefaultMedia
        {
            get
            {
                return this.Media.FirstOrDefault();
            }
        }
    }
}