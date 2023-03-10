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
    [SerializeField] private TextMeshProUGUI addText;
    [SerializeField] private AudioClip[] thankClips;
    private AudioSource audioSource;

    [SerializeField] private Image[] passengers;
    private float alpha;
    private ArrayList log;
    private bool displaying = false;
    private int time;
    private float addedTimeShow = 0;
    private float addedTimeFade = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        log = new ArrayList();
        audioSource = GetComponent<AudioSource>();
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

        if (addedTimeShow > 0)
        {
            addedTimeShow -= Time.deltaTime;
        } else
        {
            addText.alpha -= Time.deltaTime / addedTimeFade;
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
        if (!log.Contains(msg))
        {
            log.Add(msg);
        }
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
                audioSource.clip = thankClips[0];
                audioSource.Play();
                AddMessage("Rescued the Wizard!\nSpeed Increased!");
                break;
            case 2:
                // Captain
                audioSource.clip = thankClips[1];
                audioSource.Play();
                AddMessage("Rescued the Captain!\nCompass Equipped!");
                break;
            case 3:
                // Cartographer
                audioSource.clip = thankClips[2];
                audioSource.Play();
                AddMessage("Rescued the Cartographer!\nVision Improved!");
                break;
            case 4:
                // Builder
                audioSource.clip = thankClips[3];
                audioSource.Play();
                AddMessage("Rescued the Carpenter!\nCargo Expanded!");
                break;
            default:
                // code block
                break;
        }
    }

    public void setFish(int fish)
    {
        fishCount.text = " " + fish + "/" + Upgrades.capacity;
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

    public void setTime(int t)
    {
        time = t;
        timer.text = TimeToString(t);

        if (t > 5)
        {
            timer.color = Color.white;
            timer.fontSize = 36f;
        } else
        {
            timer.color = Color.red;
            timer.fontSize = 36f + 4f * Mathf.Sin(Time.time * 6f);
        }
    }

    public void addTime(int t)
    {
        if (t > 0)
        {
            addText.text = "+ " + TimeToString(t);
            addedTimeShow = 1f;
            addText.alpha = 1f;
            setTime(time + t);
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
}
