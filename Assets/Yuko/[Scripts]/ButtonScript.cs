using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public SpriteRenderer toDisabledSprite;
    public GameObject toAppearedGameObjectPrefab;

    public Vector3 toBeAppearedLocationGameObject;

    // Start is called before the first frame update
    void Start()
    {
        toDisabledSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        toBeAppearedLocationGameObject = toAppearedGameObjectPrefab.transform.position;
        toDisabledSprite.enabled = false;
        Instantiate(toAppearedGameObjectPrefab, new Vector3(toBeAppearedLocationGameObject.x, toBeAppearedLocationGameObject.y, toBeAppearedLocationGameObject.z), Quaternion.identity);
        
    }
}
