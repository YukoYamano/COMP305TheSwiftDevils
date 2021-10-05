using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonButton : MonoBehaviour
{
    [Tooltip("Image of inactive button")]
    [SerializeField] Sprite unpressed;
    [Tooltip("Image of active button")]
    [SerializeField] Sprite pressed;
    [Tooltip("The GameObject to be destoyed once button is activated")]
    [SerializeField] GameObject destructableObj;


    SpriteRenderer activeImg;

    // Start is called before the first frame update
    void Start()
    {
        activeImg = GetComponent<SpriteRenderer>();
        activeImg.sprite = unpressed;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            //Set to pressed state
            activeImg.sprite = pressed;

            //remove blocks
            Destroy(destructableObj);

        }
    }
}