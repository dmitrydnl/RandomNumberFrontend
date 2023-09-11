namespace RandomNumberFrontend;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
	}

	private async void OnAuthorizationClicked(object sender, EventArgs e)
	{
		var nickname = NicknameEntry.Text;
        var password = PasswordEntry.Text;

        var response = await Server.Authorization(nickname, password);

        var responseSuccess = response.Item1;
        var responseString = response.Item2;

        AuthRegResult.Text = $"[{responseSuccess}] {responseString}";

        if (responseSuccess)
        {
            User.Nickname = nickname;
            await Navigation.PushModalAsync(new StatisticsPage());
        }
    }

    private async void OnRegistrationClicked(object sender, EventArgs e)
    {
        var nickname = NicknameEntry.Text;
        var password = PasswordEntry.Text;

        var response = await Server.Registration(nickname, password);

        var responseSuccess = response.Item1;
        var responseString = response.Item2;

        AuthRegResult.Text = $"[{responseSuccess}] {responseString}";
    }
}
