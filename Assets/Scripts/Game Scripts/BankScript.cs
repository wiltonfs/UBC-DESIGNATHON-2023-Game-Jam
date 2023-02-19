using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankScript : MonoBehaviour
{
    private PlayerController player;
    private TimeController timeController;
    private HUDController HUD;

    private int houseCount = 0;
    private ArrayList houses;

    // Start is called before the first frame update
    void Start()
    {
        houseCount = 0;
        GetHouses();
        RenderHouses();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        HUD = GameObject.Find("HUD Controller").GetComponent<HUDController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Upgrades.population > houseCount)
        {
            houseCount = Upgrades.population;
            RenderHouses();
        }


    }

    private void GetHouses()
    {
        houses = new ArrayList();

        foreach (Transform child in transform.GetChild(0)){
            houses.Add(child.GetComponent<SpriteRenderer>());
        }

    }

    private void RenderHouses()
    {
        for (int i = 0; i < houses.Count; i++)
        {
            ((SpriteRenderer)houses[i]).enabled = (i < houseCount);

        }

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
