using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Investigator
{
    internal class UserInfo
    {
        //Decide which are needed for smurf calculation

        //64-bit Steam ID
        public string steamID { get; set; }
        //Username
        public string username { get; set; }
        //Real name
        public string realname { get; set; }
        //Whether the profile is private or not (1 = private, 3 = public)
        public int visible { get; set; }
        //Current status - 0 = Offline, 1 = Online, 2 = Busy, 3 = Away, 4 = Snooze
        public int onlineState { get; set; }
        //1 indicates the user has set up their profile
        public int profileState { get; set; }
        //Date and time the account was created
        public DateTime timeCreated { get; set; }
        //Primary group ID
        public string primaryGroupID { get; set; }
        //Country
        public string countryCode { get; set; }
        //State
        public string stateCode { get; set; }
        //City ID
        public int cityID { get; set; }
        public int personaStateFlags { get; set; }

        //How many games are in the user's library
        public int gameCount { get; set; }
        public int paidGameCount { get; set; }
        //CS:GO Info
        public bool CSGOPlayed { get; set; }
        public int CSGOPlaytime2Weeks { get; set; }
        public int CSGOPlaytimeForever { get; set; }
        public ulong CSGOLastPlayed { get; set; }
        public int CSGOAchievementCount { get; set; }
        //Dota 2 Info
        public bool Dota2Played { get; set; }
        public int Dota2Playtime2Weeks { get; set; }
        public int Dota2PlaytimeForever { get; set; }
        public ulong Dota2LastPlayed { get; set; }
        public int Dota2AchievementCount { get; set; }
        //Apex Info
        public bool ApexPlayed { get; set; }
        public int ApexPlaytime2Weeks { get; set; }
        public int ApexPlaytimeForever { get; set; }
        public ulong ApexLastPlayed { get; set; }
        public int ApexAchievementCount { get; set; }


        public UserInfo(GetPlayerSummaryInfo gPSI, GetOwnedGamesInfo gOGI, int? pGC, int CSGOAC, int DOTA2AC, int APEXAC)
        {
            //GetPlayerSummaryInfo
            if (gPSI.steamid is null)
            {
                steamID = "";
            }
            else
            {
                steamID = gPSI.steamid;
            }

            if (gPSI.personaname is null)
            {
                username = "";
            }
            else
            {
                username = gPSI.personaname;
            }

            if (gPSI.realname is null)
            {
                realname = "";
            }
            else
            {
                realname = gPSI.realname;
            }

            if (gPSI.communityvisibilitystate is null)
            {
                visible = -1;
            }
            else
            {
                visible = (int)gPSI.communityvisibilitystate;
            }

            if (gPSI.personastate is null)
            {
                onlineState = -1;
            }
            else
            {
                onlineState = (int)gPSI.personastate;
            }

            if (gPSI.profilestate is null)
            {
                profileState = -1;
            }
            else
            {
                profileState = (int)gPSI.profilestate;
            }

            if (gPSI.timecreated is null)
            {
                timeCreated = new();
            }
            else
            {
                timeCreated = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                timeCreated = timeCreated.AddSeconds((double)gPSI.timecreated);
                //timeCreated = new((ulong)gPSI.timecreated);
            }

            if (gPSI.primaryclanid is null)
            {
                primaryGroupID = "";
            }
            else
            {
                primaryGroupID = gPSI.primaryclanid;
            }

            if (gPSI.loccountrycode is null)
            {
                countryCode = "";
            }
            else
            {
                countryCode = gPSI.loccountrycode;
            }

            if (gPSI.locstatecode is null)
            {
                stateCode = "";
            }
            else
            {
                stateCode = gPSI.locstatecode;
            }

            if (gPSI.loccityid is null)
            {
                cityID = -1;
            }
            else
            {
                cityID = (int)gPSI.loccityid;
            }

            if (gPSI.personastateflags is null)
            {
                personaStateFlags = -1;
            }
            else
            {
                personaStateFlags = (int)gPSI.personastateflags;
            }

            //GetOwnedGamesInfo
            if (gOGI.game_count is null)
            {
                gameCount = -1;
            }
            else
            {
                gameCount = (int)gOGI.game_count;
            }
            if (pGC is null)
            {
                paidGameCount = -1;
            }
            else
            {
                paidGameCount = (int)pGC;
            }

            CSGOPlayed = false;
            CSGOPlaytime2Weeks = -1;
            CSGOPlaytimeForever = -1;
            CSGOLastPlayed = 0;
            Dota2Played = false;
            Dota2Playtime2Weeks = -1;
            Dota2PlaytimeForever = -1;
            Dota2LastPlayed = 0;
            ApexPlayed = false;
            ApexPlaytime2Weeks = -1;
            ApexPlaytimeForever = -1;
            ApexLastPlayed = 0;
            if (gOGI.games is not null)
            {
                foreach (var game in gOGI.games)
                {
                    if (game.appid == 730)
                    {
                        CSGOPlayed = true;
                        if (game.playtime_2weeks is null)
                        {
                            CSGOPlaytime2Weeks = 0;
                        }
                        else
                        {
                            CSGOPlaytime2Weeks = (int)game.playtime_2weeks;
                        }
                        CSGOPlaytimeForever = (int)game.playtime_forever;
                        CSGOLastPlayed = (ulong)game.rtime_last_played;
                    }
                    else if (game.appid == 570)
                    {
                        Dota2Played = true;
                        if (game.playtime_2weeks is null)
                        {
                            Dota2Playtime2Weeks = 0;
                        }
                        else
                        {
                            Dota2Playtime2Weeks = (int)game.playtime_2weeks;
                        }
                        Dota2PlaytimeForever = (int)game.playtime_forever;
                        Dota2LastPlayed = (ulong)game.rtime_last_played;
                    }
                    else if (game.appid == 1172470)
                    {
                        ApexPlayed = true;
                        if (game.playtime_2weeks is null)
                        {
                            ApexPlaytime2Weeks = 0;
                        }
                        else
                        {
                            ApexPlaytime2Weeks = (int)game.playtime_2weeks;
                        }
                        ApexPlaytimeForever = (int)game.playtime_forever;
                        ApexLastPlayed = (ulong)game.rtime_last_played;
                    }
                }
            }

            //GetPlayerAchievementInfo
            CSGOAchievementCount = CSGOAC;
            Dota2AchievementCount = DOTA2AC;
            ApexAchievementCount = APEXAC;
        }

        public override string ToString()
        {
            string str = "";
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(this);
                str += $"{name}: {value}\n";
            }
            return str;
        }
    }
}