using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fishCount;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Image messageBackground;

    [SerializeField] private Image[] passengers;
    private float alpha;
    private ArrayList log;
    private bool displaying = false;

    // Start is called before the first frame update
    void Start()
    {
        log = new ArrayList();
        HideMsg();
    }

    // Update is called once per frame
    void Update()
    {
        if (displaying)
        {
            alpha -= Time.deltaTime * 0.5f;
            if (alpha > 0)
            {
                UpdateMsgAlpha(alpha);
            } else
            {
                displaying = false;
                HideMsg();
                log.RemoveAt(0);
            }
        }

        if (log.Count > 0 && !displaying)
        {
            displaying = true;
            message.text = (string) log[0];
            alpha = 1f;
            UpdateMsgAlpha(alpha);
        }
        
    }

    private void HideMsg()
    {
        messageBackground.enabled = false;
        message.enabled = false;
    }

    private void UpdateMsgAlpha(float a)
    {
        messageBackground.enabled = true;
        message.enabled = true;
        Color tempColor = messageBackground.color;
        tempColor.a = a;
        messageBackground.color = tempColor;
        message.alpha = a;

    }

    public void AddMessage(string msg)
    {
        log.Add(msg);
    }

    public void Recruit(int passenger)
    {
        switch (passenger)
        {
            case -1:
                //Nothing
                break;
            case 1:
                // Wizard
                AddMessage("Rescued the Wizard!\nBoost Upgraded!");
                break;
            case 2:
                // Captain
                AddMessage("Rescued the Captain!\nCompass Equipped!");
                break;
            case 3:
                // Cartographer
                AddMessage("Rescued the Cartographer!\nVision Improved!");
                break;
            default:
                // code block
                break;
        }
    }

    public void setFish(int fish)
    {
        fishCount.text = "x " + fish;
    }

    public void hidePassenger()
    {
        foreach (Image img in passengers)
        {
            img.enabled = false;
        }
    }

    public void setPassenger(int passengerID)
    {
        passengers[passengerID - 1].enabled = true;
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
