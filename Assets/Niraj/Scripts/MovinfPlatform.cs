using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinfPlatform : MonoBehaviour
{
    public float rightLimit;
    public float leftLimit;
    public float speed;
    private int direction = 1;
    private Vector3 movement;

    void Update()
    {
        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }
        movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(gameObject.transform, true);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = null;
    }



    
}
