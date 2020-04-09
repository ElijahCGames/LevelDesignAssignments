using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSens = 100f;
    public Transform playerBody;
    public Transform aim;
    public GameObject TopDown;
    public GameObject ThirdPerson;
    float xRotation = 0f;
    bool NormalView = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.transform.parent = ThirdPerson.transform;
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(30, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (NormalView)
            {
                NormalView = false;
                gameObject.transform.parent = TopDown.transform;
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.Euler(80, 0f, 0f);
            }
            else
            {
                NormalView = true;
                gameObject.transform.parent = ThirdPerson.transform;
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.Euler(30, 0f, 0f);
            }
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

       /* xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        aim.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);*/

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
