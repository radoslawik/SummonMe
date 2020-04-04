![](https://github.com/radoslawik/CSharpSummonMe/blob/master/SummonMe/Assets/logo.png?raw=true)
## WPF application with MVVM pattern to retrieve League of Legends summoner information

### Requirements
- Visual Studio 2019 with C# .NET tools
- Riot Games Developer API key
- [Newtonsoft Json.NET](https://github.com/JamesNK/Newtonsoft.Json) package
- [LiveCharts.Wpf](https://github.com/Live-Charts/Live-Charts) package
- [MaterialDesignThemes](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) package

### Installation Tips
- To install dependencies you can use NuGet Package Manager or NuGet Package Console. Here you can find the tutorials for [Newtonsoft](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio), for [LiveCharts](https://lvcharts.net/App/examples/v1/wpf/Install) and for [MaterialDesignThemes](http://materialdesigninxaml.net/).
- To get your developer key you have to visit [Riot Games Developer](https://developer.riotgames.com/) website.
**Warning:** To get your key you may be asked to download the game, to play the tutorial and to confirm your email address.
- To be able to use the application you have to manually create file `API/YourDeveloperKey.txt` and paste your developer key. Make sure that file you have created is copied into output directory.
**Tip:** Key is formatted in this way `RGAPI-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx`


### Examples of valid summoner
You can search for any player, but if you do not know single summoner name you can try one of these:

Summoner  | Region
------------- | -------------
 Mitr0vav0  | EUN1
IchMagToastbrot  | EUN1
HomeWorkGuy | EUW1

**Tip:** Go to Leaderboard tab within the application to get more summoner names


### Screenshots
If you are curious how the application looks like or you have a problem with making it work, check out screenshots below:

![](https://raw.githubusercontent.com/radoslawik/CSharpSummonMe/master/Screenshots/ss1.PNG?raw=true)

![](https://raw.githubusercontent.com/radoslawik/CSharpSummonMe/master/Screenshots/ss2.PNG?raw=true)

![](https://raw.githubusercontent.com/radoslawik/CSharpSummonMe/master/Screenshots/ss3.PNG?raw=true)

![](https://raw.githubusercontent.com/radoslawik/CSharpSummonMe/master/Screenshots/ss5.PNG?raw=true)

![](https://raw.githubusercontent.com/radoslawik/CSharpSummonMe/master/Screenshots/ss4.PNG?raw=true)

### Contributors

- PUDEŁKO Radosław
- TÖREN Kutlu
- JOHANNESMEIER Niklas
