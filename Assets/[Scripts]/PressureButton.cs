using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour
{
    /// <summary>
    /// This button will only activate with a balloon or stone
    /// The button remains pressed until the weight is removed
    /// </summary>
    /// 

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
        if (collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("Stone"))
        {
            //Set to pressed state
            activeImg.sprite = pressed;
            //remove blocks
            destructableObj.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("Stone"))
        {
            //Set to pressed state
            activeImg.sprite = unpressed;
            //remove blocks
            destructableObj.SetActive(true);
        }
    }

}