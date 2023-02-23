using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private int personID = 1;
    [SerializeField] AudioClip[] calls;
    private AudioSource audioSource;

    private float callTimer;

    private PlayerController player;
    private HUDController HUD;

    private float baseWait = 1f;
    private float randomWait = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        callTimer = Time.time + baseWait + Random.Range(0f, randomWait);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        HUD = GameObject.Find("HUD Controller").GetComponent<HUDController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > callTimer)
        {
            audioSource.clip = calls[(int)Random.Range(0, calls.Length)];
            audioSource.Play();
            callTimer = Time.time + baseWait + Random.Range(0f, randomWait);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if (player.NoPassenger())
            {
                player.PickUp(personID);
                Destroy(gameObject);
            }
            else
            {
                HUD.AddMessage("Already Occupied!\nReturn home!");
            }
        }
    }
}
