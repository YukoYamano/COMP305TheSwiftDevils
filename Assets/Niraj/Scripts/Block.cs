using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public SpriteRenderer sRender;
    public Sprite newSprite;
    public GameObject block;
    


    // Start is called before the first frame update
    void Start()
    {
        sRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChngSpr(newSprite);
           
        }    
    }
    void ChngSpr(Sprite newSprite)
    {
        sRender.sprite = newSprite;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Stone")
        {
           
                block.transform.position = new Vector3(0, 3, 0);
            

        }
        
    }

}
