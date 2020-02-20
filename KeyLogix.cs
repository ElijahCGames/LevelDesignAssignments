using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogix : MonoBehaviour
{
    public GameObject targetAfter;
    public GameObject targetBefore;
    public GameObject targetDrop;

    // Start is called before the first frame update
    void Start()
    {
        targetAfter.SetActive(false);
        targetBefore.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void drop() {
        targetAfter.SetActive(false);
        targetDrop.SetActive(true);

    }

    public void pickUp() {
        targetAfter.SetActive(true);
        targetBefore.SetActive(false);
    }
}
