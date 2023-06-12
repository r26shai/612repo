using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayController: MonoBehaviour
{
    public Chromosome chromosome;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>(); // Get the Button component attached to this GameObject

        // Add a listener to the button's onClick event
        button.onClick.AddListener(StartChromosomeMovement);
    }

    public void StartChromosomeMovement()
    {
        chromosome.StartMovement();
    }
}
