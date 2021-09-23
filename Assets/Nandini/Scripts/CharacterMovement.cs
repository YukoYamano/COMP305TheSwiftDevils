using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public float horizForce;
    public float vertForce;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent < Rigidbody2D >();
       
    }

    // Update is called once per frame
    void Update()
    {
        //movement left and right
        float x = Input.GetAxisRaw("Horizontal");
        //movement Jump
        float y = Input.GetAxisRaw("Jump");

        Vector2 movement = new Vector2(x * horizForce, y * vertForce);
        rigidbody2D.AddForce(movement);


    }



}
