using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    private Transform player;
    private float rotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = player.position.x;
        float y = player.position.y;
        if (x != 0)
        {
            rotation = -1f * Mathf.Rad2Deg * Mathf.Atan(y / x) * x / Mathf.Abs(x);
        } 
        else if (y != 0)
        {
            rotation = -90f * y / Mathf.Abs(y);
        }
        Debug.Log("Expected Rotation: " +  rotation);
        this.transform.rotation = Quaternion.Euler(0, 0, rotation - 143f);
    }
}
