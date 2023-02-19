using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private int personID = 1;
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
        if (player.NoPassenger())
        {
            player.PickUp(personID);
            Destroy(gameObject);
        } 
        else
        {
            HUD.AddMessage("Boat Full!");
        }
    }
}
