using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject sphere;
    public GameObject target;
    private float timer;

    void Start() {
        timer = 0;
    }

    // Update is called once per frame
    void Update() {
        if (target != null) {
            transform.LookAt(target.transform);
        }
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer >= 1) {
            GameObject projectile;
            projectile = Instantiate(sphere, transform.position + new Vector3(0f, 0, 2f), transform.rotation);
            timer = 0;
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            target = other.gameObject;
        }
    }
}
