using Contacts.Models;

namespace Contacts.Views;

[QueryProperty(nameof(GetContactId), "Id")]
public partial class EditContactsPage : ContentPage
{
    private ContactsInfo contacts;

    public EditContactsPage() => InitializeComponent();

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public string GetContactId
    {
        set
        {
            contacts = ContactRepo.GetContactByID(int.Parse(value));
            if (contacts != null)
            {
                
                contactCtrl.Name = contacts.Name;
                contactCtrl.Email = contacts.Email;
                contactCtrl.Phone = contacts.Phone;


            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
    
        contacts.Name = contactCtrl.Name;
        contacts.Email = contactCtrl.Email;
        contacts.Phone = contactCtrl.Phone;
        ContactRepo.UpdateContacts(contacts.ContactId, contacts);
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_onError(object sender, string e)
    {
        DisplayAlert("Alert",e.ToString(),"Ok");
    }

}