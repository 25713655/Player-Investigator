using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Player_Investigator
{
    internal class GetPlayerSummaryInfo
    {
        public string? steamid { get; set; }
        public int? communityvisibilitystate { get; set; }
        public int? profilestate { get; set; }
        public string? personaname { get; set; }
        public string? profileurl { get; set; }
        public string? avatarfull { get; set; }
        public int? personastate { get; set; }
        public string? realname { get; set; }
        public string? primaryclanid { get; set; }
        public ulong? timecreated { get; set; }
        public int? personastateflags { get; set; }
        public string? loccountrycode { get; set; }
        public string? locstatecode { get; set; }
        public int? loccityid { get; set; }
    }

    internal class GetOwnedGamesInfo
    {
        //Figure out which games to do
        //Apex, CSGO, Dota2
        //CS:GO - 730
        //Dota 2 - 570
        //Apex - 1172470

        public int? game_count { get; set; }
        public List<GamesInfo>? games { get; set; }
    }

    internal class GamesInfo
    {
        public int? appid { get; set; }
        public int? playtime_2weeks { get; set; }
        public int? playtime_forever { get; set; }
        public ulong? rtime_last_played { get; set; }

    }

    internal class Queryer
    {
        //Error handling

        //https://developer.valvesoftware.com/wiki/Steam_Web_API
        //https://partner.steamgames.com/doc/webapi_overview
        //https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient
        //https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-return-types
        //https://api.steampowered.com/<interface>/<method>/v<version>/

        //https://learn.microsoft.com/en-us/samples/dotnet/samples/windowsforms-formatting-utility-cs/
        //https://stackoverflow.com/questions/61497025/c-sharp-iterate-over-a-json-object
        //https://www.epochconverter.com/

        //GetPlayerSummaries
        //GetFriendList?
        //GetPlayerAchievements/GetUserStatsForGame?
        //GetOwnedGames/GetRecentlyPlayedGames

        //Change to static?
        private HttpClient httpClient;
        public string key, steamID, output;
        public string? requestString, getPlayerSummaryResponse, getOwnedGamesResponse;
        public GetPlayerSummaryInfo? getPlayerSummaryInfo;
        public GetOwnedGamesInfo? getOwnedGamesInfo;

        //Form functions

        public Queryer(string key, string steamID)
        {
            this.key = key;
            this.steamID = steamID;
            this.key = "4DA0CD7EC93E4167D233CCF091DD4B8F"; //Remove
            this.steamID = "76561197960435530"; //Remove
            this.steamID = "76561197960434622";

            //this.steamID = "76561198271851487";
            //this.steamID = "76561198271791346";

            output = "";
            httpClient = new()
            {
                BaseAddress = new Uri("https://api.steampowered.com"),
                //BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
            };
        }

        //Other functions

        public async Task GetAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync("todos/3");

            response.EnsureSuccessStatusCode();
            WriteRequestToOutput(response);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            output += jsonResponse;
            //richTextBox1.Text = ($"{jsonResponse}\n");
        }

        public async Task<UserInfo> GetAll()
        {
            //GetPlayerSummary
            requestString = $"ISteamUser/GetPlayerSummaries/v0002/?key={key}&steamids={steamID}";
            getPlayerSummaryResponse = await GetInfo(requestString, 24, 3); //Indexes needed?

            //if (profile private) break

            //GetOwnedGames
            requestString = $"IPlayerService/GetOwnedGames/v0001/?key={key}&steamid={steamID}&include_played_free_games=1";
            getOwnedGamesResponse = await GetInfo(requestString, 12, 1);

            //Create objects with info retrieved
            getPlayerSummaryInfo = JsonSerializer.Deserialize<GetPlayerSummaryInfo>(getPlayerSummaryResponse);
            if (getPlayerSummaryInfo.communityvisibilitystate == 1)
            {
                output = "Profile is private. Cannot retrieve information.";
                return null;
            }
            getOwnedGamesInfo = JsonSerializer.Deserialize<GetOwnedGamesInfo>(getOwnedGamesResponse);

            //Create a UserInfo object with all the info retrieved
            UserInfo userInfo = new(getPlayerSummaryInfo, getOwnedGamesInfo);

            return userInfo;

            //output += userInfo.ToString();
            //var properties = getPlayerSummaryInfo.GetType().GetProperties();
            //foreach (var property in properties)
            //{
            //    var name = property.Name;
            //    var value = property.GetValue(getPlayerSummaryInfo);
            //    output += $"{name}: {value}\n";
            //}
        }

        public async Task<string> GetInfo(string request, int index1, int index2)
        {
            using HttpResponseMessage response = await httpClient.GetAsync(request);

            //try except here
            response.EnsureSuccessStatusCode();
            //WriteRequestToOutput(response);

            string responseString = await response.Content.ReadAsStringAsync();
            responseString = responseString[index1..(responseString.Length - index2)];
            //Use replace instead?
            //Replace(start, "")
            //jsonResponse = jsonResponse.Replace("]}}", "");

            output += responseString;

            return responseString;
        }

        private void WriteRequestToOutput(HttpResponseMessage response)
        {
            if (response is null)
            {
                return;
            }

            var request = response.RequestMessage;
            //string output = "";
            output += ($"{request?.Method} ");
            output += ($"{request?.RequestUri} ");
            output += ($"HTTP/{request?.Version}\n");
        }
    }
}