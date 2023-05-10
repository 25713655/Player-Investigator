using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

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

    internal class GetPlayerAchievementsInfo
    {
        public List<AchievementInfo>? achievements { get; set; }

        public GetPlayerAchievementsInfo()
        {

        }
    }

    internal class AchievementInfo
    {
        public int? achieved { get; set; }
    }

    internal class GetSteamLevelInfo
    {
        public int? player_level { get; set; }
    }

    internal class Queryer
    {
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
        public string? requestString, getPlayerSummaryResponse, getOwnedGamesResponse, getOwnedPaidGamesResponse, getPlayerAchievementsResponseCSGO, getPlayerAchievementsResponseDota2, getPlayerAchievementsResponseApex, getSteamLevelResponse;
        public GetPlayerSummaryInfo? getPlayerSummaryInfo;
        public GetOwnedGamesInfo? getOwnedGamesInfo, getOwnedPaidGamesInfo;
        public GetPlayerAchievementsInfo? getPlayerAchievementInfoCSGO, getPlayerAchievementInfoDota2, getPlayerAchievementInfoApex;
        public GetSteamLevelInfo? getSteamLevelInfo;

        //Form functions

        public Queryer(string key, string steamID)
        {
            this.key = key;
            this.steamID = steamID;

            output = "";
            httpClient = new()
            {
                BaseAddress = new Uri("https://api.steampowered.com"),
                //BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
            };
        }

        //Other functions

        public async Task<UserInfo> GetAll()
        {
            //GetPlayerSummary
            requestString = $"ISteamUser/GetPlayerSummaries/v0002/?key={key}&steamids={steamID}";
            getPlayerSummaryResponse = await GetInfo(requestString, 24, 3);

            //GetOwnedGames
            requestString = $"IPlayerService/GetOwnedGames/v0001/?key={key}&steamid={steamID}&include_played_free_games=1";
            getOwnedGamesResponse = await GetInfo(requestString, 12, 1);
            requestString = $"IPlayerService/GetOwnedGames/v0001/?key={key}&steamid={steamID}&include_played_free_games=0";
            getOwnedPaidGamesResponse = await GetInfo(requestString, 12, 1);

            //GetPlayerAchievements
            requestString = $"ISteamUserStats/GetPlayerAchievements/v0001/?appid=730&key={key}&steamid={steamID}";
            getPlayerAchievementsResponseCSGO = await GetInfo(requestString, -1, 17);
            requestString = $"ISteamUserStats/GetPlayerAchievements/v0001/?appid=570&key={key}&steamid={steamID}";
            getPlayerAchievementsResponseDota2 = await GetInfo(requestString, -1, 17);
            requestString = $"ISteamUserStats/GetPlayerAchievements/v0001/?appid=1172470&key={key}&steamid={steamID}";
            getPlayerAchievementsResponseApex = await GetInfo(requestString, -1, 17);

            //GetSteamLevel
            requestString = $"IPlayerService/GetSteamLevel/v1/?key={key}&steamid={steamID}";
            getSteamLevelResponse = await GetInfo(requestString, 12, 1);

            //Create objects with info retrieved
            try
            {
                getPlayerSummaryInfo = JsonSerializer.Deserialize<GetPlayerSummaryInfo>(getPlayerSummaryResponse);
                getOwnedGamesInfo = JsonSerializer.Deserialize<GetOwnedGamesInfo>(getOwnedGamesResponse);
                getOwnedPaidGamesInfo = JsonSerializer.Deserialize<GetOwnedGamesInfo>(getOwnedPaidGamesResponse);
                if (getPlayerAchievementsResponseCSGO == "")
                {
                    getPlayerAchievementInfoCSGO = new GetPlayerAchievementsInfo();
                }
                else
                {
                    getPlayerAchievementInfoCSGO = JsonSerializer.Deserialize<GetPlayerAchievementsInfo>(getPlayerAchievementsResponseCSGO);
                }
                if (getPlayerAchievementsResponseDota2 == "")
                {
                    getPlayerAchievementInfoDota2 = new GetPlayerAchievementsInfo();
                }
                else
                {
                    getPlayerAchievementInfoDota2 = JsonSerializer.Deserialize<GetPlayerAchievementsInfo>(getPlayerAchievementsResponseDota2);
                }
                if (getPlayerAchievementsResponseApex == "")
                {
                    getPlayerAchievementInfoApex = new GetPlayerAchievementsInfo();
                }
                else
                {
                    getPlayerAchievementInfoApex = JsonSerializer.Deserialize<GetPlayerAchievementsInfo>(getPlayerAchievementsResponseApex);
                }
                getSteamLevelInfo = JsonSerializer.Deserialize<GetSteamLevelInfo>(getSteamLevelResponse);
            }
            catch (Exception)
            {
                return null;
                throw;
            }

            //Create a UserInfo object with all the info retrieved
            int CSGOAchievements = 0, Dota2Achievements = 0, ApexAchievements = 0;
            if (getPlayerAchievementInfoCSGO.achievements is not null)
            {
                foreach (var achievement in getPlayerAchievementInfoCSGO.achievements)
                {
                    if (achievement.achieved == 1)
                    {
                        CSGOAchievements++;
                    }
                }
            }
            if (getPlayerAchievementInfoDota2.achievements is not null)
            {
                foreach (var achievement in getPlayerAchievementInfoDota2.achievements)
                {
                    if (achievement.achieved == 1)
                    {
                        Dota2Achievements++;
                    }
                }
            }
            if (getPlayerAchievementInfoApex.achievements is not null)
            {
                foreach (var achievement in getPlayerAchievementInfoApex.achievements)
                {
                    if (achievement.achieved == 1)
                    {
                        ApexAchievements++;
                    }
                }
            }
            UserInfo userInfo = new(getPlayerSummaryInfo, getOwnedGamesInfo, getOwnedPaidGamesInfo.game_count, CSGOAchievements, Dota2Achievements, ApexAchievements, getSteamLevelInfo.player_level);

            if (userInfo.visible == 1)
            {
                output += "Profile is private. Cannot retrieve information.\n";
            }
            output += userInfo.ToString();

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
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                //output += "Unable to retrieve information.\n";
                return "";
            }
            //WriteRequestToOutput(response);

            string responseString = await response.Content.ReadAsStringAsync();
            if (index1 == -1)
            {
                index1 = responseString.IndexOf("achievements") - 1;
                if (index1 < 0)
                {
                    return "";
                }
                responseString = responseString[index1..(responseString.Length - index2)];
                responseString = responseString.Insert(0, "{");
                responseString = responseString.Insert(responseString.Length, "}");
            }
            else
            {
                responseString = responseString[index1..(responseString.Length - index2)];
            }
            //Use replace instead?
            //Replace(start, "")
            //jsonResponse = jsonResponse.Replace("]}}", "");

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