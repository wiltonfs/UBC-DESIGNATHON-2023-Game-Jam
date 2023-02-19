using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int inventory;

    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        ClearInventory();

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

    public void ClearInventory()
    {
        inventory = 0;
    }

    public void AddInventory(int count)
    {
        inventory += count;
    }
}