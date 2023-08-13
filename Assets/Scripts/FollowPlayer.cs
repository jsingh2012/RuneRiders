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
    void Update () {
        if (player && player.transform)
        {
            transform.position = player.transform.position + new Vector3(0, 20f, -5f);
        }
    }
}
