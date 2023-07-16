using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public float levelTimer { get; set; }

    private void Awake()
    {
        Instance = this;
        levelTimer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer += Time.deltaTime;
        Debug.Log("levelTimer "+levelTimer);
    }

    public string GetTime()
    {
        string time = "";
        time += (int)(levelTimer / 60);
        time += ":";
        time += (int)((levelTimer % 60));
        
        return time;
    }
}
