using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Need", menuName = "ScriptableObjects/Need")]
public class Need : ScriptableObject
{
    [SerializeField]
    string label;
    public string Label { get => label; set => label = value; }

    [SerializeField]
    [Range(0, 1)]
    float value;
    public float Value
    {
        get => this.value;
        set => this.value = Mathf.Clamp01(value);
    }

    [Tooltip("How many minutes it takes for the need to drop to 0. Leave at 0 if the need should not decay.")]
    [SerializeField]
    float decayRate;
    public void Decay()
    {
        if (this.decayRate == 0) return;
        this.Value -= 1 / (this.decayRate * 60) * Time.deltaTime;
    }

    public string GetLabel()
    {
        return this.Label;
    }

    public void Reset()
    {
        this.Value = 1;
    }
}
