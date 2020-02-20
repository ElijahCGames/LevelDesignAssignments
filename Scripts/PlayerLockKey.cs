using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLockKey : MonoBehaviour
{
    private GameObject key;

    private GameObject potentialKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Key: " +key);
        Debug.Log("potKey: " + potentialKey);

        if (Input.GetKeyDown(KeyCode.E)) {
            if (potentialKey != null && key == null) {
                key = potentialKey;
                potentialKey = null;
                key.transform.SetParent(transform);
                key.GetComponent<KeyLogix>().pickUp();

            } else if(key != null ) {
                key.transform.SetParent(null);
                key.GetComponent<KeyLogix>().drop();
                key = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Key") && key == null) {
            potentialKey = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Key")) {
            potentialKey = null;
        }
    }

    /*private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Key")) {
            potentialKey = collision.gameObject;
        }
    }*/


}
