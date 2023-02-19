using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int inventory;
    [SerializeField] private TextMeshProUGUI fishCount;

    private Rigidbody2D myBody;

    private ArrayList passengers = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
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

    public ArrayList GetPassengers()
    {
        return passengers;
    }

    public void ClearInventory()
    {
        inventory = 0;
        fishCount.text = "x 0";
        passengers = new ArrayList();
    }

    public void AddInventory(int count)
    {
        inventory += count;
        fishCount.text = "x " + inventory;
    }

    public void PickUp(int personID)
    {
        passengers.Add(personID);

    }
}