using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public Transform returnPosition;
    public Transform startPosition;
    public int speed = 1;
    public bool isFacingLeft;
    public bool justTurned;
    PlayerLivesTracker livesTracker;


    private void Start()
    {
        isFacingLeft = false;
        justTurned = false;

        try
        {
            livesTracker = FindObjectOfType<PlayerLivesTracker>();
        }
        catch
        {
            Debug.Log("Unable to find PlayerLivesTracker in the scene.");
        }        

        //if (startPosition.position.x - returnPosition.position.x < 0)
        //{
        //    isFacingLeft = false;
        //}
        //else
        //{
        //    isFacingLeft = true;
        //}


    }
    private void Update()
    {
        if (isFacingLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, returnPosition.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition.position, Time.deltaTime * speed);
        }

        if (!justTurned)
        {
            float a = Mathf.Abs(transform.position.x - startPosition.position.x);
            float b = Mathf.Abs(transform.position.y - startPosition.position.y);

            float c = Mathf.Abs(transform.position.x - returnPosition.position.x);
            float d = Mathf.Abs(transform.position.y - returnPosition.position.y);

            if((a <= 0.1 && b <= 0.001)||(c <= 0.1 && d <= 0.001))
            {
                StartCoroutine(Turn());
            }
        }



        
    }


    //IEnumerator Start()
    //{
    //    isFacingLeft = true;
    //    livesTracker = FindObjectOfType<PlayerLivesTracker>();

    //    var currentPosition = transform.position;
    //    while (true)
    //    {
    //        yield return StartCoroutine(MoveObject(transform, startPosition.transform.position, returnPosition.transform.position, 3.0f));
    //        yield return StartCoroutine(MoveObject(transform, returnPosition.transform.position, startPosition.transform.position, 3.0f));
    //    }
    //}

    //IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    //{
    //    var i = 0.0f;
    //    var rate = 1.0f / time;
    //    while (i < 1.0f)
    //    {
    //        i += Time.deltaTime * rate;
    //        thisTransform.position = Vector3.Lerp(startPos, endPos, i);
    //        yield return null;
    //        if (Vector2.Distance(transform.position, returnPosition.transform.position) <= 0.001f)
    //        {
    //            //left
    //            isFacingRight = true;
    //            isFacingLeft = false;
    //            Turn();

    //        }

    //        if (Vector2.Distance(transform.position, startPosition.transform.position) <= 0.001f)
    //        {
    //            //right
    //           isFacingRight=false;
    //           isFacingLeft=true;
    //            Turn();
    //        }

    //    }


    //}
    IEnumerator Turn()
    {
        if (!justTurned)
        {
            justTurned = true;
            isFacingLeft = !isFacingLeft;
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            yield return new WaitForSeconds(1);
            justTurned = false;
        }
        
    }

}


