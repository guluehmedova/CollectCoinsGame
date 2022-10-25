using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBall : MonoBehaviour
{
    Rigidbody rigidBody;
    void Start()
    {
        
    }
    void Update()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            rigidBody.AddForce(transform.forward * 1000);
        }
    }
}
