using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractML;

public class ReggressionData : MonoBehaviour
{

    [PullFromIMLController]
    public float SetThereminParameter;

    private float previousThereminParameter;

    void Start()
    {
        
    }

    void Update()
    {
        if (SetThereminParameter == previousThereminParameter) { return; }

        print(SetThereminParameter);
        previousThereminParameter = SetThereminParameter;
    }
}
