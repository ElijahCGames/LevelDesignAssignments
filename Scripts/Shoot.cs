using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float ShootRate = .01f;
    public GameObject sphere;
    public GameObject target;
    private float timer;
    private bool BossAlive = true;

    private void Update()
    {
        if(target != null)
        {
            transform.LookAt(target.transform);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            target = other.gameObject;
            StartCoroutine(shoot());
        }

    }

    private IEnumerator shoot()
    {
        while (BossAlive)
        {
            yield return new WaitForSeconds(ShootRate);
            Instantiate(sphere, transform.position + new Vector3(0f, 0, 2f), transform.rotation);
        }
    }
}
