using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private int resourceValue = 1;
    //First val is where it starts, second val is where it ends
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
        float radius = Random.Range(spawnRange.x, spawnRange.y);
        float theta = Random.Range(0, Mathf.PI * 2);
        float x = radius * Mathf.Cos(theta);
        float y = radius * Mathf.Sin(theta);
        transform.position = new Vector2(x, y);
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        player.AddInventory(resourceValue);
        Destroy(gameObject);
    }
}
