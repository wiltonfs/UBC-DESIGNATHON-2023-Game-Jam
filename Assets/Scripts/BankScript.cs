using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankScript : MonoBehaviour
{
    private PlayerController player;
    private int homeScore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        homeScore = 0;

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D col)
    {

        homeScore += player.GetInventory();
        player.clearInventory();

        Debug.Log("Home Score: " + homeScore);

    }
}
