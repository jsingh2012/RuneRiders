using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyTowardPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float moveSpeed = 1f;

    private void Start()
    {
        target = PlayerScript.Instance.player;
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the current position to the target position
            Vector3 direction = target.transform.position - transform.position;
            
            // Normalize the direction vector to have a magnitude of 1
            direction.Normalize();
            
            // Move the object towards the target
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
