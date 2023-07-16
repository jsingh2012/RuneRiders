using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float minimumDistance = 999999999f;
    [SerializeField] private Transform nearestEnemy;
    [SerializeField] private float moveSpeed = 5f;
    private float diffx = 1;
    private float diffz = 1;
    
    private void Start()
    {
        minimumDistance = 10f;
        Debug.Log("moveWeapon childCount "+EnemyManager.Instance.enemyHolder.transform.childCount);
        this.transform.position = PlayerScript.Instance.player.transform.position;
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

        if (nearestEnemy)
        {
            nearestEnemy.transform.parent = EnemyManager.Instance.enemyWithWeaponHolder.transform;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (nearestEnemy != null)
        {
            // Calculate the direction from the current position to the target position
            diffx = nearestEnemy.transform.position.x - transform.position.x;
            diffz = nearestEnemy.transform.position.z - transform.position.z;
            
            //transform.position = new Vector3(transform.position.x + (diffx * Time.deltaTime), transform.position.y, transform.position.z + (diffz * Time.deltaTime));
            //Debug.Log("moveWeapon direction "+ diffx + " "+ diffz + " nearestEnemy "+ nearestEnemy.transform.name + " " +nearestEnemy.transform.position +" "+ transform.position);
        }
        Vector3 dir = new Vector3(diffx, 0, diffz).normalized;
        transform.position = transform.position + dir * Time.deltaTime * moveSpeed;
        
    }
}
