using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryLogic : MonoBehaviour
{
    public GameObject carryPoint;
    bool carrying;
    float dropCD = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            if (Input.GetKeyDown(KeyCode.E) && dropCD <= 0)
            {
                Debug.Log("Drop");
                carryPoint.transform.GetChild(0).transform.localPosition = new Vector3(1, -2, 0);
                carryPoint.transform.GetChild(0).transform.SetParent(null);
                carrying = false;
                //transform.position = new Vector3(0, 0, 0);
            }
            if (dropCD > 0)
            {
                dropCD -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Carryable"))
        {
            if (!carrying)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pickup");
                    other.gameObject.transform.SetParent(carryPoint.transform);
                    other.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    carrying = true;
                    dropCD = 1;
                }
            }
        }
    }
}
