namespace TwitterFeederApp.Library
{
    using System;
    using System.Globalization;
    using TwitterFeederApp.Library.Interface;

    public class TwitterBase: ITwitterBase
    {
        public string CreatedAt { get; set; }

        public DateTime CreationDate
        {
            get
            {
                if (!DateTime.TryParseExact(CreatedAt, "ddd MMM dd HH:mm:ss zzzz yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    dt = DateTime.Today;
                }

                return dt;
            }
        }
    }
}
