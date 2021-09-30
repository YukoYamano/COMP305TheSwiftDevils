using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Top_Trigger : MonoBehaviour
{
    [Tooltip("This accesses the Water_Trigger Script, Place Water Base object here")]
    public Water_Trigger Water_Trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            //Debug.Log("Stop");
            Water_Trigger.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
