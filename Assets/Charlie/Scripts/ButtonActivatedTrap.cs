using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivatedTrap : PressureButton
{

    /// <summary>
    /// This button will only activate with a balloon or stone
    /// The button remains pressed until the weight is removed
    /// In addition to removing the barrier, it will also activate a trap
    /// </summary>
    /// 

    [SerializeField] public GameObject trap;

    // Start is called before the first frame update
    void Start()
    {
        activeImg = GetComponent<SpriteRenderer>();
        activeImg.sprite = unpressed;
        trap.SetActive(false);
        destructableObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("Stone"))
        {
            //Set to pressed state
            activeImg.sprite = pressed;
            //remove blocks
            destructableObj.SetActive(false);
            trap.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("Stone"))
        {
            //Set to pressed state
            activeImg.sprite = unpressed;
            //remove blocks
            destructableObj.SetActive(true);
            trap.SetActive(false);
        }

    }
}
