using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptForDoor : MonoBehaviour
{
    

    public SpriteRenderer toDisabledSprite;
    public GameObject toDisableGameObject;


    // Start is called before the first frame update
    void Start()
    {
        
        toDisabledSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        toDisableGameObject.SetActive(false);
       

    }
}
