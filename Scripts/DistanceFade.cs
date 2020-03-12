using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceFade : MonoBehaviour
{

    public Transform sphere;
    public Transform player;

    public float min, max;
    private float r, g, b;

    private Image fadePanel;

    // Start is called before the first frame update
    void Start()
    {
        fadePanel = gameObject.GetComponent<Image>();
        r = fadePanel.color.r;
        g = fadePanel.color.g;
        b = fadePanel.color.b;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Abs((sphere.position - player.position).magnitude);
        float alphaLerp = Mathf.InverseLerp(min, max, dist);
        Debug.Log(dist);
        fadePanel.color = new Color(r,g, b, alphaLerp);
    }
}
