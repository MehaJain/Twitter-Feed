namespace TwitterFeederApp.UI.DataTemplates
{
    using TwitterFeederApp.Library;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class TwitterFeederTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TwitterFeeds { get; set; }

        public DataTemplate DirectTweets { get; set; }

        public DataTemplate Events { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {            
            if (Window.Current.Content is Frame currentFrame)
            {
                var currentPage = currentFrame.Content as Page;

                if (item != null && currentPage != null)
                {
                    if (item is TwitterFeeds)
                    {
                        return TwitterFeeds;
                    }

                    if (item is DirectTweet)
                    {
                        return DirectTweets;
                    }

                    if (item is TwitterStreamEvent)
                    {
                        return Events;
                    }
                }
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
