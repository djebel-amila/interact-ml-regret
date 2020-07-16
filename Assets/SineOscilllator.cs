using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineOscilllator : MonoBehaviour
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

    public float sampleRate = 44100;
    public float waveLengthInSeconds = 2.0f;

    AudioSource audioSource;
    int timeIndex = 0;
    float freq = 0;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = true;
        frequency1 = 433;
        frequency2 = 428;
        spatialBlend = 0; // 2D
        timeIndex = 0;
    }

    void Update()
    {
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        freq = freqMin + (y / (yMax - yMin)) * (freqMax - freqMin);

        if (spatialBlend == previousSpatialBlend) { return; }
        audioSource.spatialBlend = spatialBlend;
        previousSpatialBlend = spatialBlend;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            data[i] = CreateSine(timeIndex, freq, sampleRate);

            if (channels == 2)
            {
                data[i + 1] = CreateSine(timeIndex, freq, sampleRate);
            }

            timeIndex++;

            if (timeIndex >= (sampleRate * waveLengthInSeconds))
            {
                timeIndex = 0;
            }
        }
    }

    public float CreateSine(int timeIndex, float frequency, float sampleRate)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
    }
}
