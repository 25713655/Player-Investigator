using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Investigator
{
    internal class Calculator
    {
        //Calculator code goes here
        //https://developer.valvesoftware.com/wiki/Steam_Web_API
        //Check that for all data you could use to consider whether user is a smurf
        //The methods that I will query will probably be:
        //GetPlayerSummaries
        //GetOwnedGames/GetRecentlyPlayedGames
        //GetFriendList
        //GetPlayerAchievements/GetUserStatsForGame
        //So check the return values for those methods

        //Ideas
        //Check if avatar is default ?
        //Check for 2 in name
        //Check age of account
        //etc

        public Calculator()
        {
 public void GenerateBaseScore()
            {
                if (totalGames != "Unknown" && paidGames != "Unknown" && highestPlayTime != "Unknown" && totalPlayTime != "unkown")
                {
                    gameScore = 0;
                    if (paidGames >= 10)
                        gameScore += 5;
                    if (paidGames >= 30)
                        gameScore += 5;
                    if (totalGames >= 75)
                        gameScore += 5;
                    if (highestPlayTime >= 300)
                        gameScore += 5;
                }

              
                }

                if (numberOfFriends != "Unknown")
                {
                    friendScore = 0;
                    if (numberOfFriends >= 50)
                        friendScore += 10;
                    if (numberOfFriends >= 100)
                        friendScore += 10;
                }

                if (steamLevel != "Unknown")
                {
                    levelScore = 0;
                    if (steamLevel >= 5)
                        levelScore += 2.5;
                    if (steamLevel >= 10)
                        levelScore += 5;
                    if (steamLevel >= 15)
                        levelScore += 2.5;
                }

                if (steamBadges != "Unknown")
                {
                    badgeScore = 0;
                    if (steamBadges >= 5)
                        badgeScore += 2.5;
                    if (steamBadges >= 10)
                        badgeScore += 5;
                    if (steamBadges >= 15)
                        badgeScore += 2.5;
                }

                if (recentlyPlayedGames != "No Recently Played Games")
                {
                    recentlyPlayedScore = 0;
                    int t = recentlyPlayedGames.Length;
                    int a = 0;
                    if (t >= 2)
                        recentlyPlayedScore += 5;
                    foreach (var i in recentlyPlayedGames)
                        a += i.playtime_2weeks;
                    if (a > 120)
                        recentlyPlayedScore += 5;
                }

                }
                public void GenerateBaseScore()
                {
                    if (totalGames != "Unknown" && paidGames != "Unknown" && highestPlayTime != "Unknown")
                    {
                        gameScore = 0;
                        if (paidGames >= 10)
                            gameScore += 5;
                        if (paidGames >= 30)
                            gameScore += 5;
                        if (totalGames >= 75)
                            gameScore += 5;
                        if (highestPlayTime >= 300)
                            gameScore += 5;
                    }

                    }

                    if (numberOfFriends != "Unknown")
                    {
                        friendScore = 0;
                        if (numberOfFriends >= 50)
                            friendScore += 10;
                        if (numberOfFriends >= 100)
                            friendScore += 10;
                    }

                    if (steamLevel != "Unknown")
                    {
                        levelScore = 0;
                        if (steamLevel >= 5)
                            levelScore += 2.5;
                        if (steamLevel >= 10)
                            levelScore += 5;
                        if (steamLevel >= 15)
                            levelScore += 2.5;
                    }

                    if (steamBadges != "Unknown")
                    {
                        badgeScore = 0;
                        if (steamBadges >= 5)
                            badgeScore += 2.5;
                        if (steamBadges >= 10)
                            badgeScore += 5;
                        if (steamBadges >= 15)
                            badgeScore += 2.5;
                    }

                    if (recentlyPlayedGames != "No Recently Played Games")
                    {
                        recentlyPlayedScore = 0;
                        int t = recentlyPlayedGames.Length;
                        int a = 0;
                        if (t >= 2)
                            recentlyPlayedScore += 5;
                        foreach (var i in recentlyPlayedGames)
                            a += i.playtime_2weeks;
                        if (a > 120)
                            recentlyPlayedScore += 5;
                    }

                    if (inventoryCSGO.numOfInvItems != "Unknown" && inventoryCSGO.numOfExtItems != "Unknown")
                    {
                        inventoryScore = 0;
                        if (inventoryCSGO.numOfInvItems > 50)
                            inventoryScore += 2.5;
                        if (inventoryCSGO.numOfExtItems > 5)
                            inventoryScore += 2.5;
                    }

                    if (playerGroups != "Unknown")
                    {
                        groups
                

                if (playerGroups != "Unknown")
                {
                    groups
            
        }
        }

        //Create new function and put calculator code in there
    }
}
