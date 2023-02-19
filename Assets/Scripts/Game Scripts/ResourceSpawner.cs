using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject resource;
    [SerializeField] private int startCount;
    [SerializeField] private float spawnInterval;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startCount; i++)
            Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= timer)
        {
            Spawn();
            timer += spawnInterval;
        }
        
    }

    private void Spawn()
    {
        GameObject newResource = Instantiate(resource);
        newResource.transform.SetParent(this.transform);
    }
}
