namespace RandomNumberFrontend;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnAuthorizationClicked(object sender, EventArgs e)
	{
		var nickname = NicknameEntry.Text;
        var password = PasswordEntry.Text;
        Console.WriteLine($"Authorization {nickname} {password}");
	}
}
