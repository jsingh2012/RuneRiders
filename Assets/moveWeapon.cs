using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float minimumDistance = 999999999f;
    [SerializeField] private Transform nearestEnemy;
    [SerializeField] private float moveSpeed = 200f;
    
    private void Awake()
    {
        minimumDistance = 99999999f;
        Debug.Log("moveWeapon childCount "+EnemyManager.Instance.enemyHolder.transform.childCount);
        for(int count = 0; count < EnemyManager.Instance.enemyHolder.transform.childCount; count++)
        {
            Transform enemy = EnemyManager.Instance.enemyHolder.transform.GetChild(count);
            float distance = Vector3.Distance(enemy.position, this.transform.position);
            if ( distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = enemy;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (nearestEnemy != null)
        {
            // Calculate the direction from the current position to the target position
            Vector3 direction = nearestEnemy.transform.position - transform.position;
            direction.y = 0;
            Debug.Log("moveWeapon direction "+ direction + " nearestEnemy "+ nearestEnemy.transform.name);
            
            // Normalize the direction vector to have a magnitude of 1

            // Move the object towards the target
            transform.position = new Vector3(transform.position.x +(direction.x * moveSpeed * Time.deltaTime),transform.position.y, transform.position.z +  (direction.z * moveSpeed * Time.deltaTime) ) ;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
