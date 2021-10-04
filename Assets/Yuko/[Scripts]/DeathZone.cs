using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject boulder;
    [SerializeField] private Transform boulderSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boulder"))
        {
            Instantiate(boulder, boulderSpawnPoint.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
           

    }
}
