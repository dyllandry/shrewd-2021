using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedListDisplay : MonoBehaviour
{
    [SerializeField]
    NeedList needList;

    [SerializeField]
    GameObject needDisplayPrefab;

    [SerializeField]
    GameObject needDisplayGrid;

    private void Start()
    {
        foreach (Need need in needList.Needs)
        {
            GameObject spawnedNeedDisplay = Instantiate<GameObject>(needDisplayPrefab, needDisplayGrid.transform);
            spawnedNeedDisplay.GetComponent<NeedDisplay>().Need = need;
        }
    }
}
