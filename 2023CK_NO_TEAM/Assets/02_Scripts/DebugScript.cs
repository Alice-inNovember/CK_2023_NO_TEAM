using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public GameObject DebugCardSpawn;
    public GameObject DebugCardQue;

    public void CardSpawnActive() //Debug 용 버튼 함수
    {
        DebugCardSpawn.SetActive(true);
        DebugCardQue.SetActive(false);
    }

    public void CardQueActive() //Debug 용 버튼 함수
    {
        DebugCardQue.SetActive(true);
        DebugCardSpawn.SetActive(false);
    }
}
