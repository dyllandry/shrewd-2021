using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    NeedList needList;

    void Start()
    {
        foreach (Need need in this.needList.Needs) need.Reset();
    }

    void Update()
    {
        foreach (Need need in this.needList.Needs) need.Decay(); 
    }
}
