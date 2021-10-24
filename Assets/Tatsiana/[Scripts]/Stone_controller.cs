using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_controller : MonoBehaviour
{
    [SerializeField] LayerMask platformLayer;
    //additional distance to cast
    float extra = 0.01f;
    public bool isOnthePlatform = false;
    private BoxCollider2D boxCol;

    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        CheckOnPlatform();
    }

    void CheckOnPlatform()
    {
        
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCol.bounds.center,
            boxCol.bounds.size,
            0f,
            Vector2.down,
            extra, platformLayer);

        //Check if stone is on the Moving Platform
        if (raycastHit.collider != null && raycastHit.collider.tag == "MovingPlatform")
        {
            transform.parent = raycastHit.transform;
        }
        else
        {
            transform.parent = null;
        }
      
    }
}