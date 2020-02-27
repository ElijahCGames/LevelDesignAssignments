using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    private Light light;
    private float max;
    private float min = 0f;

    public float timeForFlash;

    static float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        max = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = Mathf.Lerp(min, max, t);

        t += 1/timeForFlash * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = max;
            max = min;
            min = temp;
            t = 0.0f;
        }
    }
}
