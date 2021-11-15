using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Destroyer : MonoBehaviour
{
    //This script is used on all traps that 'kills' the player in one hit.
    [SerializeField] private GameObject player;
   // [SerializeField] private Transform playerSpawnPoint;

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
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }
        if(other.gameObject.CompareTag("Stone") || other.gameObject.CompareTag("Balloon"))
        {
            Destroy(other.gameObject);
        }
        
    }
}