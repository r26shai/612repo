using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;

    public void ActivateScreen1()
    {
        // Activate Screen 1
        screen1.SetActive(true);

        // Deactivate other screens
        screen2.SetActive(false);
        screen3.SetActive(false);
    }

    public void ActivateScreen2()
    {
        // Activate Screen 2
        screen2.SetActive(true);

        // Deactivate other screens
        screen1.SetActive(false);
        screen3.SetActive(false);
    }

    public void ActivateScreen3()
    {
        // Activate Screen 3
        screen3.SetActive(true);

        // Deactivate other screens
        screen1.SetActive(false);
        screen2.SetActive(false);
    }
}
