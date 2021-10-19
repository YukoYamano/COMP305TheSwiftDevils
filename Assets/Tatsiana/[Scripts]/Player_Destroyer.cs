using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpawnPoint;

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
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with player detected");
            
            Instantiate(player, playerSpawnPoint.position, Quaternion.identity);
            Destroy(other.gameObject);
            Debug.Log("player instantiated");
        }
        
    }
}