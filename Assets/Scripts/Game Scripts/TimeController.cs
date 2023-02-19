using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField] private int gameTimer = 15;
    private HUDController HUD;
    private PlayerController player;
    private float tick;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.SECONDS_SURVIVED = 0;
        HUD = GameObject.Find("HUD Controller").GetComponent<HUDController>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTimes();

        if (Time.time >= tick)
        {
            tick = Time.time + 1f;
            DataManager.SECONDS_SURVIVED += 1;
            gameTimer -= 1;

            if (gameTimer < 1)
            {
                //Change Scene
                SceneManager.LoadScene("Game Lost");
            }
        }
        
    }

    private void DisplayTimes()
    {
        HUD.setTime(gameTimer);
    }

    public void AddTime(int addedTime)
    {
        gameTimer += addedTime;
    }
}
