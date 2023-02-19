using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankScript : MonoBehaviour
{
    private PlayerController player;
    private TimeController timeController;
    private HUDController HUD;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        HUD = GameObject.Find("HUD Controller").GetComponent<HUDController>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Upgrades.Recruit(player.GetPassenger());
        HUD.Recruit(player.GetPassenger());
        //BURN RATE
        timeController.AddTime((int) (player.GetInventory() * (1f - 0.1f * (float)Upgrades.population)));
        player.ClearInventory();

    }
}
