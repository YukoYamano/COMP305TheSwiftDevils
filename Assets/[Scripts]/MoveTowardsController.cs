using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsController : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed = 5.0f;
    private int currentTargetIndex;
    private bool isFacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        currentTargetIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentTargetIndex].position, Time.deltaTime * moveSpeed);
        if (Vector2.Distance(transform.position, waypoints[currentTargetIndex].position) < 0.01f)//close to target
        {   Flip();
            currentTargetIndex = (currentTargetIndex + 1) % waypoints.Count;  //remainder
            
        }
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }

}
