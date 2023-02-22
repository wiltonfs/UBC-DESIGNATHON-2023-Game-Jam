using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankScript : MonoBehaviour
{
    [SerializeField] GameObject[] characterHouses;
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

        for (int i = 0; i < 4; i++)
        {
            characterHouses[i].SetActive(false);
        }

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
        int passenger = player.GetPassenger();
        Upgrades.Recruit(passenger);
        HUD.Recruit(passenger);
        //BURN RATE
        if (player.GetInventory() > 0)
        {
            timeController.AddTime((int)(1f + (player.GetInventory() * (1f - 0.1f * (float)Upgrades.population))));
        }
        player.ClearInventory();

        if (passenger > 0)
        {
            characterHouses[passenger-1].SetActive(true);
        }
    }
}
