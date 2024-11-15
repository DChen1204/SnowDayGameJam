using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFightManager : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public int[] teamPlayerCount = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        RandomizeTeams();
    }

    /// <summary>
    /// Randomizes the teams for the players
    /// </summary>
    private void RandomizeTeams()
    {
        for (int i = 0; i < 4; i++)
        {
            int team = Random.Range(0, 2);
            if(teamPlayerCount[0] == 2) {
                team = 1;
            } else if(teamPlayerCount[1] == 2) {
                team = 0;
            }
            players[i].GetComponent<PlayerController>().team = team;
            teamPlayerCount[team]++;
        }
    }

    public void PlayerDied(int team)
    {
        teamPlayerCount[team]--;
        if(teamPlayerCount[team] == 0)
        {
            Debug.Log("Team " + team + " has lost!");
        }
    }
}
