using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{

    private PlayerLivesTracker livesTracker;    
    // Start is called before the first frame update
    void Start()
    {
       livesTracker = FindObjectOfType<PlayerLivesTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            livesTracker.IncreaseLives(1);
            Destroy(gameObject);
        }

  
    }


}
