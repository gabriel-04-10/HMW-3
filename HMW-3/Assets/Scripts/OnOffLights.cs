using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffLights : MonoBehaviour
{
    private int hasbeenpushed;
    private int hasbeenpushed2;
    private int hasbeenpushed3;
    private int hasbeenpushed4;
     public new Light light;
     private bool isRed = false;

    void Start()
    {
        ButtonForVisual buttonForVisualInstance = GetComponent<ButtonForVisual>();
        float hasbeenpushed = buttonForVisualInstance.hasBeenPushed;

        ButtonForVisual2 buttonForVisual2Instance = GetComponent<ButtonForVisual2>();
        float hasbeenpushed2 = buttonForVisual2Instance.hasBeenPushed2;

        ButtonForVisual3 buttonForVisual3Instance = GetComponent<ButtonForVisual3>();
        float hasbeenpushed3 = buttonForVisual3Instance.hasBeenPushed3;

        ButtonForVisual4 buttonForVisual4Instance = GetComponent<ButtonForVisual4>();
        float hasbeenpushed4 = buttonForVisual4Instance.hasBeenPushed4;
    }

    // Update is called once per frame
    void Update()
    {
        light = GetComponent<Light>(); 
        if (hasbeenpushed != 0 && hasbeenpushed2 != 0 && hasbeenpushed3 != 0 && hasbeenpushed4 != 0)
        {
            if (isRed)
                {
                    light.color = Color.green;
                }
            else
                {
                    light.color = Color.red;
                }
            isRed =!isRed;  
        };
    }
}
