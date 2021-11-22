using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    public float waitTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.GetComponent<PlayerController>() != null)
    //    {
    //        collision.gameObject.GetComponent<PlayerController>().isOntheIce = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<PlayerController>() != null)
    //    {
    //        StartCoroutine("SetIceFalse", collision.gameObject);
    //    }
    //}

    IEnumerator SetIceFalse(GameObject obj)
    {
        yield return new WaitForSeconds(waitTime);
        obj.GetComponent<PlayerController>().isOntheIce = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().isOntheIce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("SetIceFalse", collision.gameObject);
        }
    }


}
