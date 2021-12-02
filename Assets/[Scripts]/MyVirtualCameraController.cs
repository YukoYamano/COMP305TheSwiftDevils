using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MyVirtualCameraController : MonoBehaviour
{

    public List<GameObject> virtualCameras;
    // Start is called before the first frame update
    void Start()
    {
        virtualCameras.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            virtualCameras.Add(transform.GetChild(i).gameObject);
        }
    }

    public void TransitionTo(GameObject cameraToTransitionTo)
    {
        foreach (GameObject g in virtualCameras)
        {
            if (g == cameraToTransitionTo)
            {
                //Transition to that camera
                g.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
            else
            {
                //Deprioritize camera
                g.GetComponent<CinemachineVirtualCamera>().Priority = 5;
            }
        }

    }
}
