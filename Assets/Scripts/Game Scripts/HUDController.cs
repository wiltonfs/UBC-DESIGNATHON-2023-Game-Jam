using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fishCount;
    [SerializeField] private TextMeshProUGUI timer;

    [SerializeField] private Image passenger;
    [SerializeField] private Sprite[] passengers;


    private ArrayList log;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFish(int fish)
    {
        fishCount.text = "x " + fish;
    }

    public void hidePassenger()
    {

    }

    public void setPassenger(int passengerID)
    {
        passenger.sprite = passengers[passengerID - 1];

    }

    public void setTime(int time)
    {
        timer.text = TimeToString(time);
    }

    private string TimeToString(int time)
    {
        string ret = "" + (time / 60) + ":";

        if ((time % 60) < 10)
            ret += "0";
        ret += (time % 60);

        return ret;

    }
}
