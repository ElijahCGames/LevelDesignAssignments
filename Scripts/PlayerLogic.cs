using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public AudioSource ac;
    public AudioClip clip;
    bool playSound = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Win")) {
            ac.PlayOneShot(clip);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.CompareTag("Win") && playSound) {
            ac.PlayOneShot(clip);
            playSound = false;
        }
    }
}
