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

    public GameObject normalTerrain;
    public GameObject smellTerrain;
    float xRotation = 0f;
    bool NormalView = true;

    public float cameraRotation;
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
                StartCoroutine(moveCameraToTop());
                //gameObject.transform.localPosition = new Vector3(0, 0, 0);

                ///transform.localRotation = Quaternion.Euler(80, 0f, 0f);

                normalTerrain.SetActive(false);
                smellTerrain.SetActive(true);
            }
            else
            {
                NormalView = true;
                gameObject.transform.parent = ThirdPerson.transform;
                StartCoroutine(moveCameraToThird());
                //gameObject.transform.localPosition = new Vector3(0, 0, 0);
                //transform.localRotation = Quaternion.Euler(30, 0f, 0f);

                normalTerrain.SetActive(true);
                smellTerrain.SetActive(false);
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

    IEnumerator moveCameraToTop()
    {
        Debug.Log(Vector3.Distance(transform.position, TopDown.transform.position) < 0.01f && NormalView == false);
        while (Vector3.Distance(transform.position,TopDown.transform.position) > 0.01f && NormalView == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, TopDown.transform.position, 1);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(80, 0f, 0f), cameraRotation);
            yield return null;
        }
    }

    IEnumerator moveCameraToThird()
    {
        while (Vector3.Distance(transform.position, ThirdPerson.transform.position) > 0.01f && NormalView == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, ThirdPerson.transform.position, 1);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(30, 0f, 0f), cameraRotation);
            yield return null;
        }
    }
}
