using UnityEngine;

public class click : MonoBehaviour
{
    private AudioSource audioSource;
    private static click instance;
    
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
