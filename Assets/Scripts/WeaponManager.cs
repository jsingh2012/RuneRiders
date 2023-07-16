using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform Weapon1Prefab = null;
    [SerializeField] private Transform WeaponsParent = null;
    
    // Start is called before the first frame update
    [SerializeField] private bool canSpawnEnemy = true;
    void Start()
    {
        StartCoroutine(SpawnWeapon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SpawnWeapon()
    {
        canSpawnEnemy = true;
        yield return null;
        int count = 0;
        while (canSpawnEnemy)
        {
            //Debug.Log("New Enemy "+ Time.time);
            Transform Weapon1 = Instantiate(Weapon1Prefab, new Vector3(transform.position.x, transform.position.y+1f,transform.position.z ), Quaternion.identity);
            Weapon1.parent = WeaponsParent.transform;
            //Weapon1.GetComponent<Rigidbody>().velocity = new  Vector3(10f * transform.transform.forward.x, 0f, 10f* transform.transform.forward.z);
            Destroy(Weapon1.gameObject, 10);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
