using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shoot : MonoBehaviour
{
    public float ShootRate = .01f;
    public GameObject sphere;
    public GameObject target;
    private float timer;
    private bool BossAlive = true;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
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
            Instantiate(sphere, transform.position, transform.rotation * Quaternion.Euler(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5)));
        }
    }

    public IEnumerator moveToPlayer()
    {
        while (BossAlive)
        {
            agent.destination = target.transform.position;
            yield return null;
        }
    }
}
