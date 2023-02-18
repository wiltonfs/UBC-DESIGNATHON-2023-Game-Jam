using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;

    private int inventory;

    private Rigidbody2D myBody;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        clearInventory();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }


        myBody.position = pos;


    }

    public int GetInventory()
    {
        return inventory;
    }

    public void clearInventory()
    {
        inventory = 0;
    }

    public void addInventory(int count)
    {
        inventory += count;
    }
}