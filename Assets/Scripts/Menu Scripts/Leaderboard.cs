using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leaderboard; 
    // Start is called before the first frame update
    void Start()
    {
        string disp = "";

        for (int i = 0; i < DataManager.LEADER_BOARD_SIZE; i++)
        {
            disp += DataManager.PLAYERS[i];
            disp += " - ";
            disp += ToString(DataManager.SCORES[i]);
            disp += "\n";
        }

        leaderboard.text = disp;

        
    }

    private string ToString(int score)
    {
        string ret = "";

        if (score >= 60)
        {
            ret += score / 60;
        } else
        {
            ret += "0";
        }

        ret += ":";

        if ((score % 60) < 10)
        {
            ret += "0" + score % 60;
        }
        else
        {
            ret += score % 60;
        }

        return ret;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
