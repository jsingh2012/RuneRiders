using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public GameObject VFXHolder;
    [SerializeField] private GameObject GameOver;
    public float levelTimer { get; set; }
    public int Gems { get; set; }
    private List<Gem> gems = new List<Gem>();

    [SerializeField] private int[] powersups;
    public int nextPowerIndex = 1;
    public int playerHealth = 100;

    private void Awake()
    {
        Instance = this;
        levelTimer = 0;
        Gems = 0;
        GemScript.onGemCollected += collectGem;
        EnemyScript.onEnemyHitPlayer += damageHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer += Time.deltaTime;
        if (playerHealth <= 0)
        {
            if (GameOver)
            {
                GameOver.SetActive(true);
            }
            Invoke("delayInvoke", 0f);
        }
        //Debug.Log("levelTimer "+levelTimer);
    }

    public void delayInvoke()
    {
        Time.timeScale = 0;
    }

    public string GetTime()
    {
        string time = "";
        time += (int)(levelTimer / 60);
        time += ":";
        time += (int)((levelTimer % 60));
        
        return time;
    }

    public int GetGemsHealth()
    {
        return playerHealth;
    }
    
    public string GetGemsCount()
    {
        int current = Gems - powersups[nextPowerIndex - 1];
        return current.ToString();
    }

    public int nextMileStone()
    {
        return powersups[nextPowerIndex] - powersups[nextPowerIndex - 1];
    }
    public int prevMileStone()
    {
        return powersups[nextPowerIndex - 1];
    }
    public void collectGem(Gem gem)
    {
        Debug.Log("collectGem "+ gem.value);
        Gems += gem.value;
        if (Gems > powersups[nextPowerIndex])
        {
            nextPowerIndex++;
        }
        gems.Add(gem);
    }
    
    public void damageHealth(int damange)
    {
        playerHealth -= damange;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
    }
    
}
