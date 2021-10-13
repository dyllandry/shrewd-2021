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
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            this.cameraOffset = Quaternion.AngleAxis(1 * 90 * Time.deltaTime, Vector3.up) * cameraOffset;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            this.cameraOffset = Quaternion.AngleAxis(-1 * 90 * Time.deltaTime, Vector3.up) * cameraOffset;
        }
        transform.position = this.character.position + this.cameraOffset;
        transform.LookAt(this.character.position);
    }
}
