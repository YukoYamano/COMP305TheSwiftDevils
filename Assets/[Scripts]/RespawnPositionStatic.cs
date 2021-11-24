using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RespawnPositionStatic
{
    static int respawnPosIndex = 0;

    public static void ResetRespawn()
    {
        respawnPosIndex = 0;
    }

    public static int GetSpawnIndex()
    {
        return respawnPosIndex;
    }

    public static void SetSpawnIndex(int index)
    {
        respawnPosIndex = index;
    }
   
}
