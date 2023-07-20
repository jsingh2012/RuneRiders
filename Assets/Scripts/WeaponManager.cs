using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponAttackArrow attackArrow;
    // Start is called before the first frame update
   
    void Start()
    {
        attackArrow.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


}
