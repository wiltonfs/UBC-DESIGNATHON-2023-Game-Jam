using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DistanceHome : MonoBehaviour
{
    [SerializeField] private GameObject distanceHome;
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = distanceHome.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (int)Vector2.Distance(transform.position, Vector2.zero) + "m";
    }
}
