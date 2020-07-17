using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InteractML;

public class Theremin : MonoBehaviour
{
    const float freqMin = 400;
    const float freqMax = 600;

    const float yMin = -5;
    const float yMax = 5;

    public bool useInteractML = true;

    [PullFromIMLController]
    public float thereminParameter;

    private float y = 0;
    private float freq;
    ChuckSubInstance chuck;

    void Start()
    {

        freq = freqMin + (y / (yMax - yMin)) * (freqMax - freqMin);

        chuck = GetComponent<ChuckSubInstance>();

        // TODO this is a hack to avoid playing sound when the model is not trained
        if (useInteractML && thereminParameter == 0) return;

        chuck?.RunCode(@"
			global SinOsc s;
			s => dac;
			while( true ) { 1::second => now; }
	    ");

    }

    void Update()
    {

        if (useInteractML)
        {
            // with InteractML - thereminParameter trained at 0 and 1
            if (thereminParameter == 0) return; // TODO see above
            print(thereminParameter);
            y = Mathf.Clamp(thereminParameter, 0, 1);
            freq = freqMin + y * (freqMax - freqMin);
        }
        else
        {
            // without InteractML - translating y into frequency
            y = Mathf.Clamp(transform.position.y, yMin, yMax);
            freq = freqMin + (y / (yMax - yMin)) * (freqMax - freqMin);
        }

        chuck?.RunCode(string.Format(@"
            global SinOsc s;
		    {0} => s.freq;
		", freq));

    }

}
