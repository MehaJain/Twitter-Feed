using System;
using System.Globalization;

namespace TwitterFeederApp.Library
{
    /// <summary>
    /// Twitter User type.
    /// </summary>
    public class TwitterStreamEvent: TwitterBase
    {
        public string EventType { get; set; }

        public TwitterFeeder Source { get; set; }

        public TwitterFeeder Target { get; set; }

        public TwitterFeeds TargetObject { get; set; }
    }
}
