//using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using UnityEngine;
//using UnityEngine.UI;

//public class CopyStartStop : MonoBehaviour
//{
//    public CopyMove[] moveScripts;
//    public UnityEngine.Vector3 newDirection = UnityEngine.Vector3.right;

//    private Button button;
//    private bool isMoving = false;

//    private void Start()
//    {
//        button = GetComponent<Button>();

//        button.onClick.AddListener(ToggleMovement);
//    }

//    private void ToggleMovement()
//    {
//        if (isMoving)
//        {
//            StopMovement();
//            isMoving = false;
//            button.GetComponentInChildren<Text>().text = "Start";
//        }
//        else
//        {
//            StartMovement();
//            isMoving = true;
//            button.GetComponentInChildren<Text>().text = "Stop";
//        }
//    }

//    private void StartMovement()
//    {
//        foreach (CopyMove moveScript in moveScripts)
//        {
//            moveScript.direction = newDirection;
//            moveScript.StartMovement();
//        }
//    }

//    private void StopMovement()
//    {
//        foreach (CopyMove moveScript in moveScripts)
//        {
//            moveScript.StopMovement();
//        }
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CopyStartStop : MonoBehaviour
//{
//    public CopyMove[] moveScripts;
//    public UnityEngine.Vector3 newDirection = UnityEngine.Vector3.right;

//    public Animator fadeAnimator; // Reference to the fade animator
//    public string fadeAnimationTrigger = "FadeOut"; // Trigger parameter name for the fade animation

//    private Button button;
//    private bool isMoving = false;

//    private void Start()
//    {
//        button = GetComponent<Button>();

//        button.onClick.AddListener(ToggleMovement);
//    }

//    private void ToggleMovement()
//    {
//        if (isMoving)
//        {
//            StopMovement();
//            StopFadeAnimation();
//            isMoving = false;
//            button.GetComponentInChildren<Text>().text = "Start";
//        }
//        else
//        {
//            StartMovement();
//            StartFadeAnimation();
//            isMoving = true;
//            button.GetComponentInChildren<Text>().text = "Stop";
//        }
//    }

//    private void StartMovement()
//    {
//        foreach (CopyMove moveScript in moveScripts)
//        {
//            moveScript.direction = newDirection;
//            moveScript.StartMovement();
//        }
//    }

//    private void StopMovement()
//    {
//        foreach (CopyMove moveScript in moveScripts)
//        {
//            moveScript.StopMovement();
//        }
//    }

//    private void StartFadeAnimation()
//    {
//        if (fadeAnimator != null)
//        {
//            fadeAnimator.SetTrigger(fadeAnimationTrigger);
//        }
//    }

//    private void StopFadeAnimation()
//    {
//        if (fadeAnimator != null)
//        {
//            fadeAnimator.ResetTrigger(fadeAnimationTrigger);
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyStartStop : MonoBehaviour
{
    public CopyMove[] moveScripts;
    public UnityEngine.Vector3 newDirection = UnityEngine.Vector3.right;

    public Animator absorbanceAnimator; // Reference to the absorbance animator
    public string absorbanceAnimationTrigger = "Absorbance"; // Trigger parameter name for the absorbance animation

    public Button resetButton; // Reference to the reset button

    private Button button;
    private bool isMoving = false;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(ToggleMovement);

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetFunction);
        }
    }

    private void ToggleMovement()
    {
        if (isMoving)
        {
            StopMovement();
            StopAbsorbanceAnimation();
            isMoving = false;
            button.GetComponentInChildren<Text>().text = "Start";
        }
        else
        {
            StartMovement();
            StartAbsorbanceAnimation();
            isMoving = true;
            button.GetComponentInChildren<Text>().text = "Stop";
        }
    }

    private void StartMovement()
    {
        foreach (CopyMove moveScript in moveScripts)
        {
            moveScript.direction = newDirection;
            moveScript.StartMovement();
        }
    }

    private void StopMovement()
    {
        foreach (CopyMove moveScript in moveScripts)
        {
            moveScript.StopMovement();
        }
    }

    private void StartAbsorbanceAnimation()
    {
        if (absorbanceAnimator != null)
        {
            absorbanceAnimator.SetTrigger(absorbanceAnimationTrigger);
        }
    }

    private void StopAbsorbanceAnimation()
    {
        if (absorbanceAnimator != null)
        {
            absorbanceAnimator.ResetTrigger(absorbanceAnimationTrigger);
        }
    }

    private void ResetFunction()
    {
        // Reset the positions of your objects here.

        // Reset the start/stop button
        isMoving = false;
        button.GetComponentInChildren<Text>().text = "Start";

        // Reset the absorbance animation
        StopAbsorbanceAnimation();
    }
}
