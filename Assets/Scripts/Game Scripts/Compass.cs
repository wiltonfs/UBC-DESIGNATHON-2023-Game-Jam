using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject distanceHome;
    private float rotation;
    private TMP_Text tmpText;

    // Start is called before the first frame update
    void Start()
    {
        tmpText = distanceHome.GetComponent<TMP_Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.enabled = Upgrades.hasCompass;
        tmpText.enabled = Upgrades.hasCompass;

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
