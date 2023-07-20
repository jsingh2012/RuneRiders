using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponAttackArrow attackArrow;
    [SerializeField] private WeaonAttackMace attackPowerUp1;
    // Start is called before the first frame update
   
    void Start()
    {
        attackArrow.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.nextPowerIndex == 2 && attackPowerUp1.enabled == false)
        {
            attackPowerUp1.enabled = true;
        }
    }
    


}
