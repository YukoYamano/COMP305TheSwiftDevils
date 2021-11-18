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
    public GameObject istrigger;



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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChngSpr(newSprite);

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Stone")
        {
           
                block.transform.position = new Vector3(0, -2, 0);
                riot.transform.position = new Vector3(0, -2, 0);
            

        }
        
    }

}
