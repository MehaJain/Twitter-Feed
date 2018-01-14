namespace TwitterFeederApp.UI
{
    using System;
    using System.Linq;
    using TwitterFeederApp.UI.ViewModel;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class TwitterFeederPage
    {
        public TwitterFeederPage()
        {
            InitializeComponent();
            this.DataContext = new TwitterFeederViewModel();            
        }

        //private async void ConnectButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    this.ListView.Visibility = Visibility.Collapsed;
        //    if (this.DataContext is TwitterFeederViewModel viewModel)
        //    {
        //        var x = await viewModel.Connect();
        //        if (!x)
        //        {
        //            SearchBox.Visibility = Visibility.Collapsed;                    
        //            return;
        //        }

        //        SearchBox.Visibility = Visibility.Visible;
        //        HideCredentialsPanel();
        //        ShowSearchPanel();                
        //    }            
        //}
        
        //private async void SearchButton_OnClick(object sender, RoutedEventArgs e)
        //{            
        //    if(string.IsNullOrEmpty(this.TagText.Text))
        //    {
        //        return;
        //    }

        //    if (this.DataContext is TwitterFeederViewModel viewModel)
        //    {
        //        var collection = viewModel.Search(TagText.Text);
        //        ListView.ItemsSource = await collection;
        //        this.ListView.Visibility = Visibility.Visible;
        //        if (collection != null
        //            &&
        //            !collection.Result.Any())
        //        {
        //            SearchBox.Visibility = Visibility.Visible;                    
        //            return;
        //        }                                
        //    }            
        //}        
        
        //private void CredentialsBoxExpandButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (CredentialsBox.Visibility == Visibility.Visible)
        //    {
        //        HideCredentialsPanel();
        //    }
        //    else
        //    {
        //        ShowCredentialsPanel();
        //    }
        //}
        
        //private void SearchBoxExpandButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (SearchPanel.Visibility == Visibility.Visible)
        //    {
        //        HideSearchPanel();
        //    }
        //    else
        //    {
        //        ShowSearchPanel();
        //    }
        //}
        
        //private void ShowCredentialsPanel()
        //{
        //    CredentialsBoxExpandButton.Content = "";
        //    CredentialsBox.Visibility = Visibility.Visible;
        //}

        //private void HideCredentialsPanel()
        //{
        //    CredentialsBoxExpandButton.Content = "";
        //    CredentialsBox.Visibility = Visibility.Collapsed;            
        //}

        //private void ShowSearchPanel()
        //{
        //    SearchBoxExpandButton.Content = "";
        //    SearchPanel.Visibility = Visibility.Visible;
        //}

        //private void HideSearchPanel()
        //{
        //    SearchBoxExpandButton.Content = "";
        //    SearchPanel.Visibility = Visibility.Collapsed;
        //}        
    }
}
