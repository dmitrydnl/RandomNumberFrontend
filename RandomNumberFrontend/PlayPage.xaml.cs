namespace RandomNumberFrontend;

public partial class PlayPage : ContentPage
{
	public PlayPage()
	{
		InitializeComponent();
	}

    private async void OnPlayClicked(object sender, EventArgs e)
    {
        var myNumber = MyNumberEntry.Text;

        var response = await Server.Play(User.Nickname, myNumber);

        var responseSuccess = response.Item1;
        var responseString = response.Item2;

        PlayResult.Text = $"[{responseSuccess}] {responseString}";

        if (responseSuccess)
        {
            Thread.Sleep(500);
            await Navigation.PushModalAsync(new StatisticsPage());
        }
    }
}
