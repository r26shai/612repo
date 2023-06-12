using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SphereSplitter : MonoBehaviour
{
    public GameObject spherePrefab;  // Prefab of the smaller spheres

    public void SplitSphere()
    {
        GameObject originalSphere = gameObject;  // Get the original sphere game object

        // Calculate the scale and position of the smaller spheres
        UnityEngine.Vector3 originalScale = originalSphere.transform.localScale;
        UnityEngine.Vector3 halfScale = originalScale / 2f;
        UnityEngine.Vector3 originalPosition = originalSphere.transform.position;
        UnityEngine.Vector3 leftSpherePosition = originalPosition - halfScale;
        UnityEngine.Vector3 rightSpherePosition = originalPosition + halfScale;

        // Instantiate the smaller spheres
        GameObject leftSphere = Instantiate(spherePrefab, leftSpherePosition, UnityEngine.Quaternion.identity);
        GameObject rightSphere = Instantiate(spherePrefab, rightSpherePosition, UnityEngine.Quaternion.identity);

        // Set the scale of the smaller spheres
        leftSphere.transform.localScale = halfScale;
        rightSphere.transform.localScale = halfScale;

        // Destroy the original sphere
        Destroy(originalSphere);
    }
}
