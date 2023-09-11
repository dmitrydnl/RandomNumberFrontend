namespace RandomNumberFrontend;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();
		Welcome.Text = $"Welcome {User.Nickname}";
	}

    private void OnPlayClicked(object sender, EventArgs e)
    {
		Console.WriteLine("Play");
    }
}
