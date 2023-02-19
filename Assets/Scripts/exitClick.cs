using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitClick : MonoBehaviour
{
    private static exitClick instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClick()
    {
        audioSource.Play();
    }
}
