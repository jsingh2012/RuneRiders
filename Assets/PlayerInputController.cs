using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystickInput;

    [SerializeField] private float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Input "+joystickInput.Horizontal + " "+ joystickInput.Vertical);
        
        this.transform.position =  new Vector3(transform.position.x + (joystickInput.Horizontal*speed), transform.position.y , transform.position.z + joystickInput.Vertical *speed) ;
    }
}
