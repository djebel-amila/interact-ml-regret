using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractML;

public class Theremin : MonoBehaviour
{
    const float freqMin = 400;
    const float freqMax = 700;

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

    void Start()
    {
        ChuckSubInstance chuck = GetComponent<ChuckSubInstance>();
        if (chuck == null) return;
        chuck.RunCode(@"
		SinOsc foo => dac;
		while( true )
		{
			Math.random2f( 300, 1000 ) => foo.freq;
			100::ms => now;
		}
	    ");
    }

    void Update()
    {

        // without InteractML - translating y linearly into frequency 
        // float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        // freq = freqMin + (y / (yMax - yMin)) * (freqMax - freqMin);

        // with InteractML  
        // print(SetThereminParameter);
    }

    private void OnValidate()
    {
        if (spatialBlend == previousSpatialBlend) { return; }
        previousSpatialBlend = spatialBlend;
    }

}
