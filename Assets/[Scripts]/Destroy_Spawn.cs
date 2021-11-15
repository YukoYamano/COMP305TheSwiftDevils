using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject gobj;
    [SerializeField] private Transform spawnPoint;

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
        if (other.gameObject.CompareTag("Box"))
        {
            
            
            Instantiate(gobj, spawnPoint.position, Quaternion.identity);
            Destroy(other.gameObject);
           
        }

    }
}
