namespace RandomNumberFrontend;

public partial class StatisticsPage : ContentPage
{
    public List<int> MyGames { get; set; }
    public List<string> GlobalStatistics { get; set; }

    public StatisticsPage()
	{
		InitializeComponent();

		Welcome.Text = $"Welcome {User.Nickname}";

        Task.Run(async () =>
        {
            var response = await Server.UserStatistics(User.Nickname);

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

        Task.Run(async () =>
        {
            var response = await Server.GlobalStatistics();

            var responseSuccess = response.Item1;
            var responseDictionary = response.Item2;

            if (responseSuccess)
            {
                foreach (var (nickname, countOfGames) in responseDictionary)
                {
                    GlobalStatistics.Add($"{nickname} : {countOfGames}");
                }
            }

        });

        GlobalStatistics = new List<string> { };

        Thread.Sleep(500);

        BindingContext = this;
    }

    private async void OnPlayClicked(object sender, EventArgs e)
    {
        var response = await Server.StartGame(User.Nickname);

        var responseSuccess = response.Item1;
        var responseString = response.Item2;

        StartGameResult.Text = $"[{responseSuccess}] {responseString}";

        if (responseSuccess)
        {
            await Navigation.PushModalAsync(new PlayPage());
        }
    }
}
