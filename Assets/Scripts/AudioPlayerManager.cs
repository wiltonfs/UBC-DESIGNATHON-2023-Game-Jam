using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPlayerManager : MonoBehaviour
{
    [SerializeField] AudioClip[] songs;

    private static AudioPlayerManager instance;
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
        audioSource.clip = songs[UnityEngine.Random.Range(0, songs.Length)];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = songs[UnityEngine.Random.Range(0, songs.Length)];
            audioSource.Play();
        }
    }
}