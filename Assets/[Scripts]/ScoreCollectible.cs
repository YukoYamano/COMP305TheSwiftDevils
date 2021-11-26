using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectible : MonoBehaviour
{
    [SerializeField] int points;
    ScoreTracker scoreTracker;
    // Start is called before the first frame update
    void Start()
    {
        scoreTracker = FindObjectOfType<ScoreTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreTracker.addScore(points);
            Sound_Manager.PlaySound("coinPickUp");
            Destroy(gameObject);
        }
    }
}
