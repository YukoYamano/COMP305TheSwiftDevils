using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointBehaviour : MonoBehaviour
{
    public int index = 0;
    [SerializeField] Sprite activated;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = activated;
            GetComponentInParent<SpawnTracker>().SetRespawnLocation(index);
        }
    }

}
