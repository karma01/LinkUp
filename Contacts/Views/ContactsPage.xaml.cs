using Contacts.Models;
using System.Collections.ObjectModel;

namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();

   
    }
    /// <summary>
    /// Runs when the page appears
    /// </summary>
    protected override void OnAppearing()
    {
        LoadContacts();

        base.OnAppearing();
    }

    private void LoadContacts()
    {
        ObservableCollection<ContactsInfo> contactsList = new ObservableCollection<ContactsInfo>(ContactRepo.GetContacts()); //register to the data with observer

        listContacts.ItemsSource = contactsList;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //Perfrom the program in item Selected and null it in tapped

        //need to cache is because it will cause the error of double triggering
        if (listContacts.SelectedItem != null)
        {
            //The program
            await Shell.Current.GoToAsync($"{nameof(EditContactsPage)}?Id={((ContactsInfo)listContacts.SelectedItem).ContactId}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btn_Add_Clicked(object sender, EventArgs e)
    {

        Shell.Current.GoToAsync(nameof(AddContactsPage));
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contactsInfo = menuItem?.CommandParameter as ContactsInfo;
        if (contactsInfo != null)
        {
            ContactRepo.RemoveContact(contactsInfo.ContactId);
           
        }

        LoadContacts();

        }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
     var contactsInfo = new ObservableCollection<ContactsInfo>(  ContactRepo.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contactsInfo;

    }

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {

    }
}