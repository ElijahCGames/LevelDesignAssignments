using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    public Transform sphere;
    private Vector3 distance;
     
    // Start is called before the first frame update
    void Start()
    {
        Transform startTransform = sphere;
        distance = gameObject.transform.position - startTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = sphere.position + distance;
    }
}
