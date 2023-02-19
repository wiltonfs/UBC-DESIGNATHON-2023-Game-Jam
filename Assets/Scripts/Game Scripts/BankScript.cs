using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankScript : MonoBehaviour
{
    private PlayerController player;
    private TimeController timeController;
    private int bankedValue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        bankedValue = 0;

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        bankedValue += player.GetInventory();
        Upgrades.Recruit(player.GetPassengers());
        timeController.AddTime(player.GetInventory());
        player.ClearInventory();

    }
}
