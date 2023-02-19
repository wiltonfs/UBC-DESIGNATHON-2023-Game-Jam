using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera gameCamera;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Upgrades.hasSpyglass)
        {
            gameCamera.orthographicSize = 8f;
        } else
        {
            gameCamera.orthographicSize = 5f;
        }
        
    }
}
