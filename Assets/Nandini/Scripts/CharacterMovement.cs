using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rbody;

    public float horizForce;
    public float vertForce;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent < Rigidbody2D >();
       
    }

    // Update is called once per frame
    void Update()
    {
        //movement left and right
        float x = Input.GetAxisRaw("Horizontal");
        //movement Jump
        float y = Input.GetAxisRaw("Jump");

        Vector2 movement = new Vector2(x * horizForce, y * vertForce);
        rbody.AddForce(movement);


    }



}
