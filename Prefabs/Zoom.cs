using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody zoo = GetComponent<Rigidbody>();
        zoo.velocity = transform.TransformDirection(Vector3.forward * 10);
    }
}
