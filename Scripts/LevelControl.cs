using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject[] PillersMid;
    public GameObject[] PillersOut;
    private bool midDes;
    private bool outDes;
    private float timer = 0;
    public GameObject bp;
    // Start is called before the first frame update

    void Start()
    {
        midDes = false;
        outDes = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 10 && !midDes) {
            foreach(GameObject g in PillersMid) {
                Destroy(g);
                GameObject broke;
                broke = Instantiate(bp, g.transform.position + new Vector3(0f, -2.5f, 0f), g.transform.rotation);
            }
            midDes = true;
        }

        if (timer >= 20 && !outDes) {
            foreach (GameObject g in PillersOut) {
                Destroy(g);
                GameObject broke;
                broke = Instantiate(bp, g.transform.position + new Vector3(0f, -2.5f, 0f), g.transform.rotation);
            }
            outDes = true;
        }

    }
}
