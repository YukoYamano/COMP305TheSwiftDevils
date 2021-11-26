using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door_Behaviour : MonoBehaviour
{
    public GameObject prompt;
    // Start is called before the first frame update
    void Start()
    {
        prompt.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            prompt.GetComponent<MeshRenderer>().enabled = true;
            Sound_Manager.PlaySound("door");
        }
        if(other.CompareTag("Player") && Input.GetAxis("Fire1") > 0)
        {

            //SceneManager.LoadScene("Water Puzzle");
            RespawnPositionStatic.SetSpawnIndex(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            //--> Un-Comment this when build settings has all the scenes in order.
        }
    }
}
