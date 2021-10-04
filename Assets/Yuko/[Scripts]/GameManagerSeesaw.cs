using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSeesaw : MonoBehaviour
{
    private Animator animatorController;
    private Animator anim;


    public SpriteRenderer sRender;
    public GameObject BlackBee;

    // Start is called before the first frame update
    void Start()
    {
        anim= BlackBee.GetComponent<Animator>();
        sRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        sRender.enabled = false;
   
        anim.SetBool("isButtonPressed",true);
    }

 
}
