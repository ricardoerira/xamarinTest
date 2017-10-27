using System;
using System.Collections.Generic;
using System.Linq;
using test.Data;
using test.Model;
using Xamarin.Forms;

namespace test.Views
{
    public partial class ShowFlightsPage : ContentPage
    {
       public  RepositoryList repositoryList;
        private string toCity;
        private string fromCity;
        private DateTime date;

        public ShowFlightsPage(RepositoryList repositoryList)
        {
            InitializeComponent();
            this.repositoryList = repositoryList;
            initViews();

        }

        public ShowFlightsPage(RepositoryList repositoryList, string toCity, string fromCity, DateTime date) 
        {
            InitializeComponent();
            this.repositoryList = repositoryList;
            this.toCity = toCity;
            this.fromCity = fromCity;
            this.date = date;
            initViews();

        }

        async  void   initViews()
        {
            var listView = new ListView();
            listView.ItemSelected += OnSelection;
            List<Flight> flights;

            if(toCity != null){
             flights = this.repositoryList.flights
                    .Where(i => i.from.name == (this.fromCity))
                    .Where(i => i.to.name == (this.toCity))
                    .Where(i =>i.dateTime.Year == this.date.Year
                           && i.dateTime.Month == this.date.Month
                           && i.dateTime.Day == this.date.Day).ToList();

            }
            else{
                flights = this.repositoryList.flights;
            }
            listView.ItemsSource = flights;

            if (flights.Count()<1){
            // await   DisplayAlert("Alert", "no flights available", "OK");
                await App.Current.MainPage.DisplayAlert("Alert", "no flights available", "OK");

            }

            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(listView);   
            Content = stackLayout;
   
        }

       async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            Flight flight = e.SelectedItem as Flight;
            await Navigation.PushAsync(new BookPage(flight, repositoryList));
        }
    }
}