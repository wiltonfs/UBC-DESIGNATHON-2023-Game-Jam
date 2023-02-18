using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    [SerializeField] private float xRange = 10;
    [SerializeField] private float yRange = 10;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        Spawn();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn()
    {
        this.transform.position = new Vector2(Random.Range(-1 * xRange, xRange), Random.Range(-1 * yRange, yRange));
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        player.addInventory(1);

        Spawn();
        //Add score
        //Delete
        //Destroy(this);
    }
}
