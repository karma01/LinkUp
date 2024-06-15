namespace Contacts.Views.Control;

public partial class ContactControl : ContentView
{
	public event EventHandler<string> onError;
    public event EventHandler<EventArgs> OnSuccess;
    public event EventHandler<EventArgs> OnCancel;


    public ContactControl() => InitializeComponent();
    public  string Name
	{
		get { return entryName.Text; }
		set { entryName.Text = value; }

	}
    public string Phone
    {
        get { return entryPhone.Text; }
        set { entryPhone.Text = value; }
    }
    public string Email
    {
        get { return entryEmail.Text; }
        set { entryEmail.Text = value; }

    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            onError?.Invoke(sender, "Enter a proper name.");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            if (emailValidator.Errors != null)
            {
                foreach (var error in emailValidator.Errors)
                {
                    onError?.Invoke(sender, error.ToString());

                }
            }
            return;
        }
        OnSuccess?.Invoke(sender, e);
        


    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {

        OnCancel?.Invoke(sender, e);

    }
}