using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextReader : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float textTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 5f)) {
            if (hit.collider.gameObject.CompareTag("Readable")) {
                text.text = hit.collider.gameObject.GetComponent<TextObject>().text;
                textTimer = 3;
            }

        }
        if(textTimer > 0) {
            textTimer -= Time.deltaTime;
        }
        else {
            text.text = "";
        }
    }
}
