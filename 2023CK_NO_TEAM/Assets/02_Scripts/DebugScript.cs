using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public GameObject DebugCardSpawn;
    public GameObject DebugCardQue;

    public void CardSpawnActive()
    {
        DebugCardSpawn.SetActive(true);
        DebugCardQue.SetActive(false);
    }

    public void CardQueActive()
    {
        DebugCardQue.SetActive(true);
        DebugCardSpawn.SetActive(false);
    }
}
