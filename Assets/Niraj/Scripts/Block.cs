using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public SpriteRenderer sRender;
    public Sprite newSprite;
    public GameObject block;
    public GameObject riot;
    public GameObject Player;
    



    // Start is called before the first frame update
    void Start()
    {
        sRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    void ChngSpr(Sprite newSprite)
    {
        sRender.sprite = newSprite;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) || collision.gameObject.tag == "Stone")
        {
            
            

                ChngSpr(newSprite);
                block.transform.position = new Vector3(0, -2, 0);
                riot.transform.position = new Vector3(0, -2, 0);
            

        }
        
    }

}
