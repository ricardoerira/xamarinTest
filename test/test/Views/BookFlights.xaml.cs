using System;
using System.Collections.Generic;
using test.Data;
using test.Model;
using test.Util;
using Xamarin.Forms;

namespace test.Views
{
    public partial class BookFlights : ContentPage
    {

        public RepositoryList repositoryList;
        Button buttonSearch;
        Picker pickerTo;
        Picker pickerFrom;
        DatePicker datePicker;
        string fromCity;
        string toCity;
        public BookFlights(RepositoryList repositoryList)
        {
            InitializeComponent();
            this.repositoryList = repositoryList;
            initViews();


        }
        public void initViews()
        {
            pickerTo = new Picker { Title = "Select a city to" };
            pickerTo.ItemsSource = this.repositoryList.cities;

            pickerFrom = new Picker { Title = "Select a city from" };
            pickerFrom.ItemsSource = this.repositoryList.cities;

            pickerTo.SelectedIndexChanged += Handle_Select;
            pickerFrom.SelectedIndexChanged += Handle_Select;

            Label headerFrom = new Label
            {
                Text = "From",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label headerTo = new Label
            {
                Text = "To",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label headerDate = new Label
            {
                Text = "Date",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };


            datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button buttonSearch = new Button
            {
                Text = "Search",
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            
            };
            buttonSearch.Clicked += Handle_Clicked;


            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(headerFrom);

            stackLayout.Children.Add(pickerFrom);

            stackLayout.Children.Add(headerTo);

            stackLayout.Children.Add(pickerTo);
                        
            stackLayout.Children.Add(headerDate);

            stackLayout.Children.Add(datePicker);

            stackLayout.Children.Add(buttonSearch);


            Content = stackLayout;


        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if(Validates.validateSearch(fromCity,toCity)){
                await Navigation.PushAsync(new ShowFlightsPage(this.repositoryList, toCity, fromCity, datePicker.Date));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Fill all fields", "OK");

            }

        }
         void Handle_Select(object sender, System.EventArgs e)
        {
            Picker picker = sender as Picker;
            if (picker.SelectedIndex == -1)
                {
                }
                else
                {
                if (picker.Title ==  "Select a city to")
                    toCity = picker.Items[picker.SelectedIndex];
                if (picker.Title ==  "Select a city from")
                    fromCity = picker.Items[picker.SelectedIndex];
                
                }
        }

        public DateTime onDateSelected(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
           return new DateTime(year, monthOfYear + 1, dayOfMonth);

        }


    }
}
