using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using System;

public class Leaderboard : MonoBehaviour
{
    private static string publicKey = "e369c1b0f92d44752a35ef7149a9cd2cdb5aa292129e7bc4991c1eaa76a3d784";
    private static List<(string, int)> data;
    public static bool isInitialized = false;

    void Start() {
        data = new List<(string, int)>();
    }

    public static List<(string, int)> GetData() { return data; }

    public static List<(string, int)> GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) => {

            data = new List<(string, int)>();
            for (int i = 0; i < msg.Length; i++) 
            {
                data.Add((msg[i].Username, msg[i].Score));
            }
        }));
        
        return data;
    }

    public static void SetLeaderboardEntry(string name, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, name, score, ((msg) => {
            GetLeaderboard();
        }));
    }
}
