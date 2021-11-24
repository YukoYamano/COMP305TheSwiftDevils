using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Destroyer : MonoBehaviour
{
    public GameObject sizzleAudio;
    //This script is used on all traps that 'kills' the player in one hit.
    [SerializeField] private GameObject player;
    // [SerializeField] private Transform playerSpawnPoint;
    PlayerLivesTracker livesTracker;
    // Start is called before the first frame update
    void Start()
    {
        livesTracker = FindObjectOfType<PlayerLivesTracker>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            livesTracker.DecreaseLives();

            //Instantiate(sizzleAudio);

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);


        }
        if(other.gameObject.CompareTag("Stone") || other.gameObject.CompareTag("Balloon"))
        {
            Destroy(other.gameObject);
        }
        
    }
}