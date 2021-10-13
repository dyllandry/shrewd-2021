using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform character;

    Vector3 cameraOffset;

    private void OnEnable()
    {
        this.cameraOffset = this.transform.position - this.character.position;
    }

    private void Update()
    {
        this.transform.position = this.character.position + this.cameraOffset;
    }
}
