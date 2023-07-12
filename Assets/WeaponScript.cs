using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;

    [SerializeField] private PlayerInputController playerScript;
    // Start is called before the first frame update

    [SerializeField] private float x = 0f;
    [SerializeField] private float z = 0f;
    void Start()
    {
        x = playerScript.InputX;
        z = playerScript.InputZ;
    }

   
}
