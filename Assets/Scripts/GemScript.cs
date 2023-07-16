using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public delegate void OnGemCollected(Gem gem);
    
    public static OnGemCollected onGemCollected;
    
    private Gem gem = new Gem(1);

    // Start is called before the first frame update
    private void Awake()
    {
        gem.collected = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("GemScript other " + other.gameObject.tag);
        if (gem.collected == false && other.CompareTag("Player"))
        {
            Collect();
        }
    }
    
    private void Collect()
    {
        gem.collected = true;
        if (onGemCollected != null) onGemCollected(gem);
        Destroy(this.gameObject);
    }
}
