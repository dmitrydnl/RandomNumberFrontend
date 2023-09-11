namespace RandomNumberFrontend;

public partial class StatisticsPage : ContentPage
{
    public List<int> MyGames { get; set; }

    public StatisticsPage()
	{
		InitializeComponent();
        var nickname = User.Nickname;
		Welcome.Text = $"Welcome {nickname}";
        var task = Task.Run(async () =>
        {
            var response = await Server.UserStatistics(nickname);

            var responseSuccess = response.Item1;
            var responseList = response.Item2;

            if (responseSuccess)
            {
                foreach (var game in responseList)
                {
                    MyGames.Add(game);
                }
            }

        });
        MyGames = new List<int> { };
        BindingContext = this;
    }

    private void OnPlayClicked(object sender, EventArgs e)
    {
		Console.WriteLine("Play");
    }
}
