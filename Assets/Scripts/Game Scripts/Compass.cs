using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;
    private float rotation;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.enabled = Upgrades.hasCompass;
        
        float x = player.position.x;
        float y = player.position.y;
        if (x > 0)
        {
            rotation = 180f + Mathf.Rad2Deg * Mathf.Atan(y / x);

        } else
        {
            rotation = Mathf.Rad2Deg * Mathf.Atan(y / x);
        }

        this.transform.rotation = Quaternion.Euler(0, 0, rotation - 90f);
    }
}
