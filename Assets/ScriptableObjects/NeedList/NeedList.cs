using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeedList", menuName = "ScriptableObjects/NeedList")]
public class NeedList : ScriptableObject
{
    public List<Need> Needs; 
}
