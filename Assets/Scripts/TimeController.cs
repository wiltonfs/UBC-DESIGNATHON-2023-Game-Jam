using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField] private TextMeshPro timer;
    [SerializeField] private TextMeshPro collectedTimer;

    private int gameTimer;
    private PlayerController player;
    private float tick;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gameTimer = 15;
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTimes();

        if (Time.time > tick)
        {
            gameTimer -= 1;
            tick = Time.time + 1;
        }
        
    }

    private string TimeToString(int time)
    {
        string ret = "" + (time / 60) + ":";

        if ((time % 60) < 10)
            ret += "0";
        ret += (time % 60);

        return ret;

    }

    private void DisplayTimes()
    {
        timer.text = TimeToString(gameTimer);
        collectedTimer.text = "+ " + TimeToString(player.GetInventory());
    }

    public void AddTime(int addedTime)
    {
        gameTimer += addedTime;
    }
}
