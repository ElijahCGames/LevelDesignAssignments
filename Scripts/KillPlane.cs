using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public Transform checkpoint;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        transform.position = checkpoint.position;
        transform.rotation = checkpoint.rotation;
    }

}
