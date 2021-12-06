using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cameraToActivate;
    [SerializeField] private GameObject cameraOut;
    [SerializeField] private float zoomTime=2.5f;
    private float shortZoomTime, userZoomTime;
    public MyVirtualCameraController vCamController;

    void Start()
    {
        shortZoomTime = 2.5f;
        userZoomTime = zoomTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            zoomTime = shortZoomTime;
            Debug.Log("zoom time: " + zoomTime);
            vCamController.TransitionTo(cameraToActivate);
            StartCoroutine(Delay());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e"))
        {
            zoomTime = userZoomTime;
            Debug.Log("zoom time: " + zoomTime);
            vCamController.TransitionTo(cameraToActivate);
            StartCoroutine(Delay());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            vCamController.TransitionTo(cameraOut);
            
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(zoomTime);
        vCamController.TransitionTo(cameraOut);

    }

}
