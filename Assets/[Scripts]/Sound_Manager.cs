using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public static AudioClip coinPickUp;
    static AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        coinPickUp = Resources.Load<AudioClip>("coinPickUp");

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "coinPickUp":
                source.PlayOneShot(coinPickUp);
                break;
        }
    }
}
