using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Investigator
{
    internal class Calculator
    {
        public UserInfo userInfo;
        public string output;

        public Calculator(UserInfo uI)
        {
            userInfo = uI;
            output = "";
        }

        private const int MaxScore = 100;

        private const int TimePlayedWeight = 15;
        private const int NumFriendsWeight = 20;
        private const int SteamLevelWeight = 10;
        private const int AccountAgeWeight = 35;
        private const int AchievementCountWeight = 5;
        private const int PaidGameCountWeight = 35;

        private const int MaxTimePlayed = 100;
        private const int MinNumFriends = 10;
        private const int MinSteamLevel = 10;
        private const int MaxAccountAgeInDays = 365;
        private const int MinAchievementCount = 10;
        private const int MinPaidGameCount = 5;

        public double CheckSmurfAccount(string game)
        {
            int timePlayed = 0, numFriends = 0, steamLevel = userInfo.level, achievementCount = 0, paidGameCount = userInfo.paidGameCount;
            DateTime accountCreationDate = userInfo.timeCreated;

            switch (game)
            {
                case "CS:GO":
                    if (userInfo.CSGOPlayed == false)
                    {
                        output += "User has never played CS:GO.\n";
                        //return -1;
                        timePlayed = 0;
                        achievementCount = 0;
                    }
                    else
                    {
                        timePlayed = userInfo.CSGOPlaytimeForever / 60;
                        achievementCount = userInfo.CSGOAchievementCount;
                    }
                    break;

                case "Dota 2":
                    if (userInfo.Dota2Played == false)
                    {
                        output += "User has never played Dota 2.\n";
                        //return -1;
                    }
                    else
                    {
                        timePlayed = userInfo.Dota2PlaytimeForever / 60;
                        achievementCount = userInfo.Dota2AchievementCount;
                    }
                    break;

                case "Apex Legends":
                    if (userInfo.ApexPlayed == false)
                    {
                        output += "User has never played Apex Legends.\n";
                        //return -1;
                    }
                    else
                    {
                        timePlayed = userInfo.ApexPlaytimeForever / 60;
                        achievementCount = userInfo.ApexAchievementCount;
                    }
                    break;
            }

            int timePlayedScore = CalculateScore(timePlayed, MaxTimePlayed) * TimePlayedWeight;
            //int numFriendsScore = CalculateScore(numFriends, MinNumFriends) * NumFriendsWeight;
            int steamLevelScore = CalculateScore(steamLevel, MinSteamLevel) * SteamLevelWeight;
            int accountAgeScore = CalculateAccountAgeScore(accountCreationDate) * AccountAgeWeight;
            int achievementCountScore = CalculateScore(achievementCount, MinAchievementCount) * AchievementCountWeight;
            int paidGameCountScore = CalculateScore(paidGameCount, MinPaidGameCount) * PaidGameCountWeight;

            int numFriendsScore = 0;
            int overallScore = timePlayedScore + numFriendsScore + steamLevelScore + accountAgeScore + achievementCountScore + paidGameCountScore;

            int maxScore = MaxScore * (TimePlayedWeight + SteamLevelWeight + AccountAgeWeight + AchievementCountWeight + PaidGameCountWeight);
            double percentage = (double)overallScore / maxScore * 100;

            output += $"Calculated percentage: {percentage}";

            return percentage;
        }

        private int CalculateScore(int value, int threshold)
        {
            if (value <= threshold)
            {
                return MaxScore;
            }

            double ratio = (double)threshold / value;
            return (int)(MaxScore * ratio);
        }

        private int CalculateAccountAgeScore(DateTime accCreationDate)
        {
            TimeSpan age = DateTime.Now - accCreationDate;
            int accountAgeInDays = (int)age.TotalDays;

            if (accountAgeInDays <= MaxAccountAgeInDays)
            {
                return MaxScore;
            }

            double ratio = (double)MaxAccountAgeInDays / accountAgeInDays;
            return (int)(MaxScore * ratio);
        }
    }
}
