using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyReset : MonoBehaviour
{
    public Transform[] objectsToReset; // Array of objects to reset
    public Transform[] targetObjects; // Array of target objects to return to
    public float resetTime = 2f; // Time taken to reset the objects (in seconds)
    private UnityEngine.Vector3[] initialPositions; // Array of initial positions of the objects
    private bool isResetting = false; // Flag to indicate if the objects are currently being reset

    private void Start()
    {
        initialPositions = new UnityEngine.Vector3[objectsToReset.Length];
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            initialPositions[i] = objectsToReset[i].position;
        }
    }

    public void ResetObjects()
    {
        if (!isResetting)
        {
            StartCoroutine(ResetCoroutine());
        }
    }

    private IEnumerator ResetCoroutine()
    {
        isResetting = true;

        // Store the current positions of the objects
        UnityEngine.Vector3[] currentPositions = new UnityEngine.Vector3[objectsToReset.Length];
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            currentPositions[i] = objectsToReset[i].position;
        }

        // Reset each object to its corresponding target object over resetTime duration
        float t = 0f;
        while (t < resetTime)
        {
            t += Time.deltaTime;
            for (int i = 0; i < objectsToReset.Length; i++)
            {
                Transform obj = objectsToReset[i];
                Transform targetObj = targetObjects[i];
                obj.position = UnityEngine.Vector3.Lerp(currentPositions[i], targetObj.position, t / resetTime);
            }
            yield return null;
        }

        // Set each object's position to its corresponding target object's position
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            Transform obj = objectsToReset[i];
            Transform targetObj = targetObjects[i];
            obj.position = targetObj.position;
        }

        isResetting = false;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Numerics;
//using UnityEngine;
//using UnityEngine.UI;

//public class CopyReset : MonoBehaviour
//{
//    public Transform[] objectsToReset; // Array of objects to reset
//    public Transform[] targetObjects; // Array of target objects to return to
//    public float resetTime = 2f; // Time taken to reset the objects (in seconds)
//    private UnityEngine.Vector3[] initialPositions; // Array of initial positions of the objects
//    private bool isResetting = false; // Flag to indicate if the objects are currently being reset

//    private void Start()
//    {
//        initialPositions = new UnityEngine.Vector3[objectsToReset.Length];
//        for (int i = 0; i < objectsToReset.Length; i++)
//        {
//            initialPositions[i] = objectsToReset[i].position;
//        }
//    }

//    public void ResetObjects()
//    {
//        if (!isResetting)
//        {
//            StartCoroutine(ResetCoroutine());
//        }
//    }

//    private System.Collections.IEnumerator ResetCoroutine()
//    {
//        isResetting = true;

//        // Store the current positions of the objects
//        UnityEngine.Vector3[] currentPositions = new UnityEngine.Vector3[objectsToReset.Length];
//        for (int i = 0; i < objectsToReset.Length; i++)
//        {
//            currentPositions[i] = objectsToReset[i].position;
//        }

//        // Reset each object to its corresponding target object over resetTime duration
//        float t = 0f;
//        while (t < resetTime)
//        {
//            t += Time.deltaTime;
//            for (int i = 0; i < objectsToReset.Length; i++)
//            {
//                Transform obj = objectsToReset[i];
//                Transform targetObj = targetObjects[i];
//                obj.position = UnityEngine.Vector3.Lerp(currentPositions[i], targetObj.position, t / resetTime);
//            }
//            yield return null;
//        }

//        // Set each object's position to its corresponding target object's position
//        for (int i = 0; i < objectsToReset.Length; i++)
//        {
//            Transform obj = objectsToReset[i];
//            Transform targetObj = targetObjects[i];
//            obj.position = targetObj.position;
//        }

//        isResetting = false;
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Numerics;
//using UnityEngine;
//using UnityEngine.UI;

//public class CopyReset : MonoBehaviour
//{
//    public Transform[] objectsToReset; // Array of objects to reset
//    public UnityEngine.Vector3[] resetPositions; // Array of reset positions for each object
//    public float resetTime = 2f; // Time taken to reset the objects (in seconds)
//    private UnityEngine.Vector3[] initialPositions; // Array of initial positions of the objects
//    private bool isResetting = false; // Flag to indicate if the objects are currently being reset

//    private void Start()
//    {
//        initialPositions = new UnityEngine.Vector3[objectsToReset.Length];
//        for (int i = 0; i < objectsToReset.Length; i++)
//        {
//            initialPositions[i] = objectsToReset[i].position;
//        }
//    }

//    public void ResetObjects()
//    {
//        if (!isResetting)
//        {
//            StartCoroutine(ResetCoroutine());
//        }
//    }

//    private System.Collections.IEnumerator ResetCoroutine()
//    {
//        isResetting = true;

//        // Store the current positions of the objects
//        UnityEngine.Vector3[] currentPositions = new UnityEngine.Vector3[objectsToReset.Length];
//        for (int i = 0; i < objectsToReset.Length; i++)
//        {
//            currentPositions[i] = objectsToReset[i].position;
//        }

//        // Reset each object to its corresponding initial position over resetTime duration
//        float t = 0f;
//        while (t < resetTime)
//        {
//            t += Time.deltaTime;
//            for (int i = 0; i < objectsToReset.Length; i++)
//            {
//                Transform obj = objectsToReset[i];
//                obj.position = UnityEngine.Vector3.Lerp(currentPositions[i], initialPositions[i], t / resetTime);
//            }
//            yield return null;
//        }

//        // Set each object's position to its corresponding initial position
//        for (int i = 0; i < objectsToReset.Length; i++)
//        {
//            Transform obj = objectsToReset[i];
//            obj.position = initialPositions[i];
//        }

//        isResetting = false;
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using UnityEngine;
//using UnityEngine.UI;

//public class CopyReset : MonoBehaviour
//{
//    public Transform sphere1; // Reference to the first sphere transform
//    public Transform sphere2; // Reference to the second sphere transform
//    public Transform sphere3; // Reference to the third sphere transform
//    public Transform sphere4; // Reference to the fourth sphere transform
//    //public Transform sphere5; // Reference to the fifth sphere transform
//    //public Transform sphere6; // Reference to the sixth sphere transform
//    //public Transform sphere7; // Reference to the seventh sphere transform
//    //public Transform sphere8; // Reference to the eighth sphere transform

//    private Button resetButton;

//    private UnityEngine.Vector3 initialPosition1; // Initial position of sphere 1
//    private UnityEngine.Vector3 initialPosition2; // Initial position of sphere 2
//    private UnityEngine.Vector3 initialPosition3; // Initial position of sphere 3
//    private UnityEngine.Vector3 initialPosition4; // Initial position of sphere 4
//    //private UnityEngine.Vector3 initialPosition5; // Initial position of sphere 5
//    //private UnityEngine.Vector3 initialPosition6; // Initial position of sphere 6
//    //private UnityEngine.Vector3 initialPosition7; // Initial position of sphere 7
//    //private UnityEngine.Vector3 initialPosition8; // Initial position of sphere 8

//    private void Start()
//    {
//        resetButton = GetComponent<Button>(); // Get the Button component attached to this GameObject
//        resetButton.onClick.AddListener(ResetSpheres); // Add a listener to the button's onClick event

//        // Store the initial positions of the spheres
//        initialPosition1 = sphere1.position;
//        initialPosition2 = sphere2.position;
//        initialPosition3 = sphere3.position;
//        initialPosition4 = sphere4.position;
//        //initialPosition5 = sphere5.position;
//        //initialPosition6 = sphere6.position;
//        //initialPosition7 = sphere7.position;
//        //initialPosition8 = sphere8.position;
//    }

//    private void ResetSpheres()
//    {
//        // Reset the position of sphere 1 to its initial position
//        sphere1.position = initialPosition1;

//        // Reset the position of sphere 2 to its initial position
//        sphere2.position = initialPosition2;

//        // Reset the position of sphere 3 to its initial position
//        sphere3.position = initialPosition3;

//        // Reset the position of sphere 4 to its initial position
//        sphere4.position = initialPosition4;

//        //// Reset the position of sphere 5 to its initial position
//        //sphere5.position = initialPosition5;

//        //// Reset the position of sphere 6 to its initial position
//        //sphere6.position = initialPosition6;

//        //// Reset the position of sphere 7 to its initial position
//        //sphere7.position = initialPosition7;

//        //// Reset the position of sphere 8 to its initial position
//        //sphere8.position = initialPosition8;
//    }
//}
