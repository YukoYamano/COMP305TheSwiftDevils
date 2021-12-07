using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    [SerializeField] GameObject heartFX;
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
            FindObjectOfType<Sound_Manager>().Play("heart");
            livesTracker.IncreaseLives(1);
            GameObject obj = Instantiate(heartFX.gameObject, collision.transform);
            collision.transform.parent = obj.transform;
            Destroy(gameObject);
        }

  
    }


}
