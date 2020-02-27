using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject projectilePrefab;
    public Image reticleImage;
    public Color reticleColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;

            if (!projectile.GetComponent<Rigidbody>()) {
                projectile.AddComponent<Rigidbody>();
            }
            var rb = projectile.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);
            projectile.transform.SetParent(GameObject.FindGameObjectWithTag("ProjParent").transform);

        }
        ReticleEffect();
    }

    void ReticleEffect() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)){
            if (hit.collider.CompareTag("Dementor")) {
                reticleImage.color = new Color(reticleColor.r, reticleColor.g, reticleColor.b, 1f);
            }
            else {
                reticleImage.color = Color.Lerp(reticleImage.color, reticleColor, 2 * Time.deltaTime);
            }
        }
    }
}
