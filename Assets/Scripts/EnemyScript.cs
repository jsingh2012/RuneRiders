using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Jsingh "+ this.gameObject.name);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter other " + other.gameObject.name);
        if (other.CompareTag("Weapon"))
        {
            Destroy(other.transform.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("OnTriggerEnter other "+other.gameObject.name);
    }
}
