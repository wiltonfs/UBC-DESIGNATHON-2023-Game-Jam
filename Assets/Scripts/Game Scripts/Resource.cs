using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private int resourceValue = 1;
    private PlayerController player;

    private HUDController HUD;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        HUD = GameObject.Find("HUD Controller").GetComponent<HUDController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if (!player.Full())
            {
                player.AddInventory(resourceValue);
                Destroy(gameObject);
            }
            else
            {
                HUD.AddMessage("Boat Full!\nReturn home!");
            }
        }
    }
}
