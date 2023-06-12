using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome : MonoBehaviour
{
    public Transform startPoint; // Public variable to store the starting point of movement
    public Transform endPoint; // Public variable to store the end point of movement
    public float duration = 10f; // Public variable to specify the duration of movement

    private bool isMoving = false;
    private float timer = 0f; // Private variable to track the progress of the movement 

    // Update is called once per frame
    void Update()
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
            Vector3 newPos = Vector3.Lerp(startPoint.position, endPoint.position, smoothT);
            transform.position = newPos;
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
}
