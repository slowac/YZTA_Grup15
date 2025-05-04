using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class LightFlickerGradient : MonoBehaviour
{
    public Gradient colorGradient; 
    public float flickerSpeed = 0.05f;   
    public float flickerChance = 0.4f;   
    public float minIntensity = 0.2f;
    public float maxIntensity = 1f;

    private Light lightSource;
    private float defaultIntensity;

    void Start()
    {
        lightSource = GetComponent<Light>();
        defaultIntensity = lightSource.intensity;
        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(flickerSpeed);

            if (Random.value < flickerChance)
            {
                float t = Random.value;
                lightSource.color = colorGradient.Evaluate(t);
                lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
            }
            else
            {
                lightSource.color = colorGradient.Evaluate(1f);
                lightSource.intensity = defaultIntensity;
            }
        }
    }
}
