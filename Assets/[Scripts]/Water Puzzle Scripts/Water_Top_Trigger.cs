using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Top_Trigger : MonoBehaviour
{
    [Tooltip("This accesses the Water_Trigger Script, Place Water Base object here")]
    public GameObject Water_Base;

    private Collider2D waterBaseCollider;
    // Start is called before the first frame update
    void Start()
    {
        waterBaseCollider = Water_Base.GetComponent<Collider2D>();
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().mass<=1)
        {
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            //Debug.Log("Stop");
            waterBaseCollider.isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().mass <= 1)
        {
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            
        }
    }
}
