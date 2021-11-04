using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinfPlatformUp : MonoBehaviour
{
    public float UpLimit;
    public float DownLimit;
    public float speed;
    private int direction = 1;
    private Vector3 movement;

    void Update()
    {
        if (transform.position.y > UpLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < DownLimit)
        {
            direction = 1;
        }
        movement = Vector3.up * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(gameObject.transform, true);
        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        
    }
}
