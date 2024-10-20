using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    private string publicKey = "e369c1b0f92d44752a35ef7149a9cd2cdb5aa292129e7bc4991c1eaa76a3d784";

    private List<string> names;
    private List<int> values;

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) => {
            for(int i = 0; i < names.Count; i++) {
                names[i] = msg[i].Username;
                values[i] = msg[i].Score;
            }
        }));
    }

    public void SetLeaderboardEntry(string name, int score)
    {
        
    }
}
