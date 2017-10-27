using System;
using System.Collections.Generic;
using System.Linq;
using test.Data;
using Xamarin.Forms;

namespace test.Views
{
    public partial class BookbyClient : ContentPage
    {
        public RepositoryList repositoryList;
        public ListView listView = new ListView();

        public BookbyClient(RepositoryList repositoryList)
        {
            InitializeComponent();
            this.repositoryList = repositoryList;
            initViews();

        }
          public  void initViews()
        {
            SearchBar sb = new SearchBar
            {
                Placeholder = "Type here to search by client identification "
            };
            sb.TextChanged += (object sender, TextChangedEventArgs e) => {
                 SearchBar_OnTextChanged(sender, e);
            };

            listView.ItemsSource = this.repositoryList.books;

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(sb);

            stackLayout.Children.Add(listView);
            Content = stackLayout;

        }
        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int number;
            bool isNumeric = int.TryParse(e.NewTextValue, out number);
                               
            if (isNumeric)
            {
                listView.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    listView.ItemsSource = this.repositoryList.books;
                else
                    listView.ItemsSource = this.repositoryList.books.Where(i => i.client.identification == (number));

                listView.EndRefresh();
            }
            else{
                listView.ItemsSource = this.repositoryList.books;

            }
        }
    }
}
