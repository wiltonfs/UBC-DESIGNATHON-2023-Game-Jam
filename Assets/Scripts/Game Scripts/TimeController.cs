using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField] private TextMeshPro timer;
    [SerializeField] private TextMeshPro collectedTimer;

    [SerializeField] private int gameTimer = 15;
    private PlayerController player;
    private float tick;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.SECONDS_SURVIVED = 0;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTimes();

        if (Time.time > tick)
        {
            DataManager.SECONDS_SURVIVED += 1;
            gameTimer -= 1;
            if (gameTimer < 1)
            {
                //Change Scene
                SceneManager.LoadScene("Game Lost");
            }

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
