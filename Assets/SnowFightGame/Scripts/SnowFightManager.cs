using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFightManager : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    private int team1Count = 0;
    private int team2Count = 0;
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
            int team = Random.Range(1, 3);
            if(team1Count == 2) {
                team = 2;
            } else if(team2Count == 2) {
                team = 1;
            }
            players[i].GetComponent<PlayerController>().team = team;
            if (team == 1)
            {
                team1Count++;
            }
            else
            {
                team2Count++;
            }
        }
    }
}
