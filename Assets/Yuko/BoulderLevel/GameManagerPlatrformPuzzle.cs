using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPlatrformPuzzle : MonoBehaviour
{
   private Animator animatorController;
   private Animator anim;


    public SpriteRenderer toDisabledSprite;
    public GameObject spawnObject;


    // Start is called before the first frame update
    void Start()
    {
       anim = spawnObject.GetComponent<Animator>();
        toDisabledSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        spawnObject.SetActive(true);
        toDisabledSprite.enabled = false;
        anim.SetBool("isButtonPressed", true);
    }
}
