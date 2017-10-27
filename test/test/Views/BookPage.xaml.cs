using System;
using System.Collections.Generic;
using test.Controller;
using test.Data;
using test.Model;
using test.Util;
using Xamarin.Forms;

namespace test.Views
{
    public partial class BookPage : ContentPage
    {
        BookController bookController;
        Flight flight;
        Button buttonBook;
        Label flightLabel;
        Editor identificationEditor;
        Editor ageEditor;
        Editor nameEditor;
        RepositoryList repositoryList;

        public BookPage(Flight flight,RepositoryList repositoryList)
        {
            InitializeComponent();
            this.flight = flight;
            bookController = new BookController(repositoryList);
            initViews();

        }
        public void initViews()
        {
            Label identificationLabel = new Label
            {
                Text = "Identification",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            identificationEditor = new Editor
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                BackgroundColor = Device.OnPlatform(Color.FromHex("#A4EAFF"),
                                                    Color.FromHex("#2c3e50"),
                                                    Color.FromHex("#2c3e50")),
            };

            Label nameLabel = new Label
            {
                Text = "Name",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            nameEditor = new Editor
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                BackgroundColor = Device.OnPlatform(Color.FromHex("#A4EAFF"),
                                                    Color.FromHex("#2c3e50"),
                                                    Color.FromHex("#2c3e50"))
            };

            Label ageLabel = new Label
            {
                Text = "Age",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            ageEditor = new Editor
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                BackgroundColor = Device.OnPlatform(Color.FromHex("#A4EAFF"),
                                                    Color.FromHex("#2c3e50"),
                                                    Color.FromHex("#2c3e50"))
            };

            Label flightTextLabel = new Label
            {
                Text = "Flight",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };


            flightLabel = new Label
            {
                Text = this.flight.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            buttonBook = new Button
            {
                Text = "Book",
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };      
            buttonBook.Clicked += Handle_Clicked;

            StackLayout stackLayout = new StackLayout();

            stackLayout.Children.Add(identificationLabel);

            stackLayout.Children.Add(identificationEditor);

            stackLayout.Children.Add(nameLabel);


            stackLayout.Children.Add(nameEditor);

            stackLayout.Children.Add(ageLabel);


            stackLayout.Children.Add(ageEditor);

            stackLayout.Children.Add(flightTextLabel);

            stackLayout.Children.Add(flightLabel);


            stackLayout.Children.Add(buttonBook);

            Content = stackLayout;


        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (Validates.validateBook(identificationEditor.Text,ageEditor.Text,nameEditor.Text) ){
                if( bookController.availableBook(flight,nameEditor.Text, ageEditor.Text, identificationEditor.Text))
                    bookController.createBook(flight, nameEditor.Text, ageEditor.Text, identificationEditor.Text);
                else
                    await App.Current.MainPage.DisplayAlert("Alert", "No chairs available", "OK");

            }
            else{
                await App.Current.MainPage.DisplayAlert("Alert", "Fill all fields", "OK");
 
            }

        }
    }
}
