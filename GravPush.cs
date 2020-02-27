using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravPush : MonoBehaviour
{
    public Transform aim;
    public float mass = 3.0f;
    public float pushForce;
    public CharacterController charContr;
    public Vector3 impact = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (Physics.Raycast(aim.position, aim.forward, out hit, 5f)) {
                if (hit.collider != null) {
                    addImpact(new Vector3(aim.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0) * -1, pushForce);
                }
                else {

                }
            }
        }
        if (impact.magnitude > 0.2) {
            charContr.Move(impact * Time.deltaTime);
        }
        
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }

    void addImpact(Vector3 dir, float force) {
        dir.Normalize();
        if (dir.y < 0) 
            dir.y = -dir.y;
        print(dir);
        impact += dir.normalized * force / mass;
    }

}
