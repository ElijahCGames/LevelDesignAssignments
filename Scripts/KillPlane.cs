using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public Transform checkpoint;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KP")) {
            transform.position = checkpoint.position;
            transform.rotation = checkpoint.rotation;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("KP")) {
            transform.position = checkpoint.position;
            transform.rotation = checkpoint.rotation;
        }
    }

}
