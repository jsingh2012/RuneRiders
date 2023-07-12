using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] public Transform player;

    void Start()
    {
        
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + new Vector3(0, 9.64f, -12.81f);
    }
}
