using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public static AudioClip coinPickUp, pickUpItem, balloonPop, dropItem, door, fan;
    static AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        coinPickUp = Resources.Load<AudioClip>("coinPickUp");
        pickUpItem = Resources.Load<AudioClip>("pickUpItem");
        balloonPop = Resources.Load<AudioClip>("balloonPop");
        dropItem = Resources.Load<AudioClip>("dropItem");
        door = Resources.Load<AudioClip>("door");
        fan = Resources.Load<AudioClip>("fan");

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
                source.PlayOneShot(coinPickUp, 10f);
                break;
            case "pickUpItem":
                source.PlayOneShot(pickUpItem);
                break;
            case "balloonPop":
                source.PlayOneShot(balloonPop);
                break;
            case "dropItem":
                source.PlayOneShot(dropItem);
                break;
            case "door":
                source.PlayOneShot(door);
                break;
            case "fan":
                source.PlayOneShot(fan);
                break;
            case "":
                source.Stop();
                break;
        }
    }
}
