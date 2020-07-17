using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractML;

public class Theremin : MonoBehaviour
{
    const float freqMin = 400;
    const float freqMax = 600;

    const float yMin = -5;
    const float yMax = 5;

    [PullFromIMLController]
    public float SetThereminParameter;

    private float y = 0;
    private float freq;
    ChuckSubInstance chuck;

    void Start()
    {

        freq = freqMin + (y / (yMax - yMin)) * (freqMax - freqMin);

        chuck = GetComponent<ChuckSubInstance>();
        if (chuck == null) { return; }

        chuck.RunCode(@"
			global SinOsc s;
			// play it forever
			s => dac;
		
			while( true ) { 1::second => now; }
	    ");

    }

    void Update()
    {

        // without InteractML - translating y linearly into frequency 
        y = Mathf.Clamp(transform.position.y, yMin, yMax);
        freq = freqMin + (y / (yMax - yMin)) * (freqMax - freqMin);

        if (chuck == null) { return; }
        chuck.RunCode(string.Format(@"
                global SinOsc s;
				{0} => s.freq;
			", freq));

        // with InteractML  
        // print(SetThereminParameter);

    }

}
