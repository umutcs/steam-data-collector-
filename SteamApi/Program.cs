using System;
using System.Net.Http;
using SteamWebAPI2;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;

class Program
{
    static async Task Main(string[] args)
    {
        var webInterfaceFactory = new SteamWebInterfaceFactory("2EDCB9C589BAC36AEEA34FC390F24E0E");
        var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());
        ulong steamid = 76561198211665876;

       var steamURL = "https://steamcommunity.com/id/wonska";

        var playerSummaryResponse = await steamInterface.GetPlayerSummaryAsync(steamid);
        var playerSummaryData = playerSummaryResponse.Data;

        var avatarurl = playerSummaryData.AvatarFullUrl;
        var nickname = playerSummaryData.Nickname;

        
        var realName = playerSummaryData.RealName;


        var friendslistresponse = await steamInterface.GetFriendsListAsync(steamid);
        var friendsList = friendslistresponse.Data;

        Console.WriteLine(nickname);

        foreach (var friend in friendsList)
        {
            Console.WriteLine($"Friend SteamID: {friend.SteamId}");
            Console.WriteLine($"Relationship: {friend.Relationship}");
            Console.WriteLine($"Friend Since: {friend.FriendSince}");
            Console.WriteLine();
        }
        Console.WriteLine(avatarurl);
        Console.WriteLine("His real name is : {0}",realName);
        

    }
}
