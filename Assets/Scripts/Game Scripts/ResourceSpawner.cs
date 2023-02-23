using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject resource;
    [SerializeField] private Vector2 spawnRange;
    [SerializeField] private int startCount;
    [SerializeField] private float spawnInterval;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + spawnInterval;
        for (int i = 0; i < startCount; i++)
            Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= timer)
        {
            Spawn(); //Spawn a fish
            timer = Time.time + spawnInterval;
        }
        
    }

    private void Spawn()
    {
        float radius = Random.Range(spawnRange.x, spawnRange.y);
        float theta = Random.Range(0, Mathf.PI * 2);
        float x = radius * Mathf.Cos(theta);
        float y = radius * Mathf.Sin(theta);
        x += transform.position.x;
        y += transform.position.y;

        Vector2 newPos = new Vector2(x, y);

        GameObject newResource = Instantiate(resource, newPos, Quaternion.identity);
        newResource.transform.SetParent(this.transform);
    }
}
