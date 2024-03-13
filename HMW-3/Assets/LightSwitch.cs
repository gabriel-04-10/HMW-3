using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public new Light light;
    public InputActionReference action;
    private bool isGreen = false;
    void Update()
    {
        light = GetComponent<Light>(); 
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (isGreen)
                {
                    light.color = Color.green;
                }
            isGreen = !isGreen;
        };
    }
}

