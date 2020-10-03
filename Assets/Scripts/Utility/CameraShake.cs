using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Transform target;
    Vector3 initialPos;

    bool isShaking = false;

    [Range(0f, 2f)]
    public float intensity = 0.5f;

    void Start()
    {
        target = GetComponent<Transform>();
        initialPos = target.localPosition;
    }

    float pendingShakeDuration = 0;

    public void Shake(float duration) 
    {
        if (duration > 0)
        {
            pendingShakeDuration += duration;
        }
    }

    private void Update()
    {
        if (pendingShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake() 
    {
        isShaking = true;

        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-1, 1) * intensity, Random.Range(-1, 1) * intensity, initialPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }

        pendingShakeDuration = 0;
        target.localPosition = initialPos;
        isShaking = false;
    }
}
