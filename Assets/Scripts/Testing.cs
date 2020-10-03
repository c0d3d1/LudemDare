using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public CameraShake cameraShake;

    [SerializeField] float shakeDur = 2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraShake.Shake(shakeDur);
        }
    }
}
