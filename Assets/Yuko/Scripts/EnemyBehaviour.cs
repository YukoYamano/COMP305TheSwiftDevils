using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public GameObject returnPosition;
    public GameObject startPosition;
    public bool isFacingRight = false;
    public bool isFacingLeft = true;
    PlayerLivesTracker livesTracker;





    IEnumerator Start()
    {
        isFacingLeft = true;
        livesTracker = FindObjectOfType<PlayerLivesTracker>();

        var currentPosition = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, startPosition.transform.position, returnPosition.transform.position, 3.0f));
            yield return StartCoroutine(MoveObject(transform, returnPosition.transform.position, startPosition.transform.position, 3.0f));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
            if (Vector2.Distance(transform.position, returnPosition.transform.position) <= 0.001f)
            {
                //left
                isFacingRight = true;
                isFacingLeft = false;
                Turn();

            }

            if (Vector2.Distance(transform.position, startPosition.transform.position) <= 0.001f)
            {
                //right
               isFacingRight=false;
               isFacingLeft=true;
                Turn();
            }

        }


    }
    void Turn()
    {
       
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
 

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            livesTracker.DecreaseLives();
        }
    }
}


