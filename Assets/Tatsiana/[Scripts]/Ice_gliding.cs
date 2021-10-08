using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_gliding : MonoBehaviour
{
    public float glidingSpeed;
    private bool isGliding =false;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //void FixedUpdate()
    //{
    //    if (isGliding)
    //    {
    //        Glide();

    //    }

    //    void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ice"))
    //    {
    //        Debug.Log($"player is on the Ice");
    //            isGliding = true;
    //        }
    //}

    //void Glide()
    //{
    // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,0f)* glidingSpeed;
    //}





    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 0f) * glidingSpeed;

        }

    }

    
}
