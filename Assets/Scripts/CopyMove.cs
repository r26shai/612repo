using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class CopyMove : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float duration = 2f;

    private float timer = 0f;
    public UnityEngine.Vector3 direction = UnityEngine.Vector3.right;

    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            timer += Time.deltaTime;

            if (timer > duration)
            {
                timer = duration;
                isMoving = false;
            }

            float t = timer / duration;
            float smoothT = Mathf.SmoothStep(0f, 1f, t);

            UnityEngine.Vector3 curvePosition = CalculateCurvePosition(startPoint.position, endPoint.position, smoothT);
            transform.position = curvePosition;
        }
    }

    public void StartMovement()
    {
        if (!isMoving)
        {
            timer = 0f;
            isMoving = true;
        }
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    public UnityEngine.Vector3 CalculateCurvePosition(UnityEngine.Vector3 startPoint, UnityEngine.Vector3 endPoint, float t)
    {
        UnityEngine.Vector3 controlPoint1 = startPoint + (endPoint - startPoint) * 0.33f;
        UnityEngine.Vector3 controlPoint2 = endPoint - (endPoint - startPoint) * 0.33f;

        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        UnityEngine.Vector3 curvePosition = uuu * startPoint +
                                3f * uu * t * controlPoint1 +
                                3f * u * tt * controlPoint2 +
                                ttt * endPoint;

        return curvePosition;
    }
}
