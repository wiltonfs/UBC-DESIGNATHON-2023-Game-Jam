using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int inventory;
    private int passenger;
    private Rigidbody2D myBody;
    private HUDController HUD;

    private ArrayList passengers = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        HUD = GameObject.Find("HUD Controller").GetComponent<HUDController>();
        ClearInventory();
        Upgrades.Reset();

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = myBody.position;
        float speed = Upgrades.moveSpeed;

        //If have speed upgrade
        if (Input.GetKey(KeyCode.LeftShift) && Upgrades.hasSprint)
        {
            speed *= Upgrades.sprintMultiplier;
        }

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        myBody.position = pos;


    }

    public int GetInventory()
    {
        return inventory;
    }

    public int GetPassenger()
    {
        return passenger;
    }

    public void ClearInventory()
    {
        inventory = 0;
        HUD.setFish(inventory);
        HUD.hidePassenger();
        passenger = -1;
    }

    public void AddInventory(int count)
    {
        inventory += count;
        HUD.setFish(inventory);
    }

    public void PickUp(int personID)
    {
        passenger = personID;
        HUD.setPassenger(personID);

    }

    public bool NoPassenger()
    {
        return passenger == -1;
    }

    public bool Full()
    {
        return inventory > 19;
    }
}