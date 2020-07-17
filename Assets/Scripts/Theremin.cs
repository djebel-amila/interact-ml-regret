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

    [Range(freqMin, freqMax)]
    public float frequency1;

    [Range(freqMin, freqMax)]
    public float frequency2;

    [Range(0, 1)]
    public float spatialBlend;

    private float previousSpatialBlend = 0;

    [PullFromIMLController]
    public float SetThereminParameter;

    private float freq;

    ChuckSubInstance chuck;

    void Start()
    {

        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        freq = freqMin + (y / (yMax - yMin)) * (freqMax - freqMin);

        chuck = GetComponent<ChuckSubInstance>();

        if (chuck == null)
        {
            //    print("ChuckSubInstance is null");
            return;
        }

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
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        freq = freqMin + (y / (yMax - yMin)) * (freqMax - freqMin);

        GetComponent<ChuckSubInstance>().RunCode(string.Format(@"
                global SinOsc s;
				{0} => s.freq;
			", freq));

        // with InteractML  
        // print(SetThereminParameter);
    }

    private void OnValidate()
    {
        if (spatialBlend == previousSpatialBlend) { return; }
        previousSpatialBlend = spatialBlend;
    }

}
