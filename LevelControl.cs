using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject[] PillersMid;
    public GameObject[] PillersOut;
    private bool midDes = false;
    private bool outDes = false;
    private float timer = 0;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 10 && !midDes) {
            foreach(GameObject g in PillersMid) {
                Destroy(g);
            }
        }

        if (timer >= 20 && !outDes) {
            foreach (GameObject g in PillersOut) {
                Destroy(g);
            }
        }

    }
}
