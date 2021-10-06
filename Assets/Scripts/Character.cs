using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    List<Need> Needs;

    void Start()
    {
        foreach (Need need in this.Needs) need.Reset();
    }

    void Update()
    {
        foreach (Need need in this.Needs) need.Decay(); 
    }
}
