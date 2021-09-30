using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScene : MonoBehaviour
{
    public float lifeTime =10f;
    public Transform BoulderSpawnPoint;
    private float seconds;
    //public Transform StoneSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0f;
      
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        Debug.Log(seconds);

        if(Math.Floor(seconds) == lifeTime)
        {
            Instantiate(this.gameObject, BoulderSpawnPoint.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
