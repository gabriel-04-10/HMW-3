using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    public Transform playerTarget;
    public Transform mirror;

    void Start()
    {

    }

    void Update()
    {
        Vector3 localPlayer = mirror.InverseTransformPoint(playerTarget.position);
        transform.position = mirror.position;

        Vector3 lookatmirror = mirror.TransformPoint(new Vector3(-localPlayer.x, -localPlayer.y, -localPlayer.z));
        transform.LookAt(lookatmirror, mirror.up);
    }
}
