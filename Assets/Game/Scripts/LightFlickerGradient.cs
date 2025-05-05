using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlickerGradient : MonoBehaviour
{
    public Gradient colorGradient;
    public float minIntensity = 0.2f;
    public float maxIntensity = 1f;
    public AudioSource audioSource; // Ses kaynaðý

    public float gainMultiplier = 50f;

    private Light lightSource;
    private float[] audioSamples = new float[64]; // Spektrum deðil, raw amplitude için

    void Start()
    {
        lightSource = GetComponent<Light>();

        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource atanmadý!");
        }
    }

    void Update()
    {
        if (audioSource == null) return;

        audioSource.GetOutputData(audioSamples, 0); // L kanal
        float sum = 0f;

        foreach (float sample in audioSamples)
        {
            sum += Mathf.Abs(sample);
        }

        float averageAmplitude = sum / audioSamples.Length;
        float t = Mathf.Clamp01(averageAmplitude * gainMultiplier);

        lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
        lightSource.color = colorGradient.Evaluate(t);
    }
}
