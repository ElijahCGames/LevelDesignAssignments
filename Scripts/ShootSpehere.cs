using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpehere : MonoBehaviour
{
    [SerializeField]
    private GameObject sphere = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            GameObject projectile;
            projectile = Instantiate(sphere, transform.position + new Vector3(0,0,0),transform.rotation);
        }
    }
}
