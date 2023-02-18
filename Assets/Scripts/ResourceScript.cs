using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    [SerializeField] private int resourceValue = 1;
    [SerializeField] private Vector2 spawnRange;

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
        this.transform.position = new Vector2(Random.Range(-1 * spawnRange.x, spawnRange.x), Random.Range(-1 * spawnRange.y, spawnRange.y));
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        player.AddInventory(resourceValue);

        Spawn();
        //Add score
        //Delete
        //Destroy(this);
    }
}
