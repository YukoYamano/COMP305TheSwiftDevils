using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTracker : MonoBehaviour
{
    [SerializeField]GameObject[] savePoints;
    public int currentSavePoint;


    private void Awake()
    {
        currentSavePoint = RespawnPositionStatic.GetSpawnIndex();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public Vector3 GetRespawnLocation()
    {
        return savePoints[currentSavePoint].transform.position;
    }

    public void SetRespawnLocation(int index)
    {
        currentSavePoint = index;
        RespawnPositionStatic.SetSpawnIndex(currentSavePoint);
    }


    
}
