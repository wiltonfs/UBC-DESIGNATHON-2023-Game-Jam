using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Compass : MonoBehaviour
{
    private Rigidbody2D player;
    private float rotation;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private Image arrow;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        arrow.enabled = Upgrades.hasCompass;
        distanceText.enabled = Upgrades.hasCompass;

        float x = player.position.x;
        float y = player.position.y;
        float distance = Mathf.Sqrt(x * x + y * y);
        if (x > 0)
        {
            rotation = 180f + Mathf.Rad2Deg * Mathf.Atan(y / x);

        } else
        {
            rotation = Mathf.Rad2Deg * Mathf.Atan(y / x);
        }
        distanceText.text = "" + (int) distance + "m";
        this.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
