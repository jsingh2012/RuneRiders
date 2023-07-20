using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public GameObject VFXHolder;
    public float levelTimer { get; set; }
    public int Gems { get; set; }
    private List<Gem> gems = new List<Gem>();

    private void Awake()
    {
        Instance = this;
        levelTimer = 0;
        Gems = 0;
        GemScript.onGemCollected += collectGem;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer += Time.deltaTime;
        //Debug.Log("levelTimer "+levelTimer);
    }

    public string GetTime()
    {
        string time = "";
        time += (int)(levelTimer / 60);
        time += ":";
        time += (int)((levelTimer % 60));
        
        return time;
    }
    public string GetGemsCount()
    {
        return Gems.ToString();
    }
    void collectGem(Gem gem)
    {
        Debug.Log("collectGem "+ gem.value);
        Gems += gem.value;
        gems.Add(gem);
    }
    
}
