using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Destroyer : MonoBehaviour
{
    //This script is used on all traps that 'kills' the player in one hit.

    // [SerializeField] private Transform playerSpawnPoint;
    PlayerLivesTracker livesTracker;

    private bool removingLife;
    // Start is called before the first frame update
    void Start()
    {
        removingLife = false;
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

            StartCoroutine(RemoveLife());



        }
        if(other.gameObject.CompareTag("Stone") || other.gameObject.CompareTag("Balloon"))
        {
            Destroy(other.gameObject);
        }
        
    }

    IEnumerator RemoveLife()
    {
        Debug.Log("Remove Life called");
        if (removingLife == false)
        {
            removingLife = true;
            livesTracker.DecreaseLives();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            yield return new WaitForSeconds(1);
            removingLife = false;
        }
        
    }
}