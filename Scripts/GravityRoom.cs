using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRoom : MonoBehaviour
{
    public float GravityLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<Rigidbody>()) {
            other.gameObject.GetComponent<Rigidbody>().mass = GravityLevel;
        }else if (other.CompareTag("Player")){
            other.GetComponent<PlayerGravityMovement>().GravityChange(-9.81f * GravityLevel);

        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerGravityMovement>().GravityChange(other.GetComponent<PlayerGravityMovement>().defaultGravity);

        }
    }
}
