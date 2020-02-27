using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    private Light light;
    private float max;
    private float min = 0f;

    public float timeForFlash;

    private float H, S, V;
    static float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        Color.RGBToHSV(light.color, out H, out S, out V);
        max = V;
    }

    // Update is called once per frame
    void Update()
    {
        light.color = Color.HSVToRGB(H,S, Mathf.Lerp(min, max, t));

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
