using Contacts.Models;

namespace Contacts.Views;

public partial class AddContactsPage : ContentPage
{
	public AddContactsPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");


    }

    private void contactCtrl_OnSuccess(object sender, EventArgs e)
    {

        ContactRepo.AddContact(new ContactsInfo
        {
            Name = contactCtrl.Name,Email = contactCtrl.Email,Phone = contactCtrl.Phone,


        });
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_onError(object sender, string e)
    {
        DisplayAlert("Alert", e, "Ok");

    }
}