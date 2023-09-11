namespace RandomNumberFrontend;

public partial class StatisticsPage : ContentPage
{
    public List<int> MyGames { get; set; }

    public StatisticsPage()
	{
		InitializeComponent();
		Welcome.Text = $"Welcome {User.Nickname}";
        MyGames = new List<int> { 123, 23, 1, 90 };
        BindingContext = this;
    }

    private void OnPlayClicked(object sender, EventArgs e)
    {
		Console.WriteLine("Play");
    }
}
