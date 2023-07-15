using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Player player = new Player(100);
    public int TotalGemValue { get; set; }
    private List<Gem> gems = new List<Gem>();

    private void Awake()
    {
        Instance = this;
        GemScript.onGemCollected += collectGem;
    }

    void collectGem(Gem gem)
    {
        Debug.Log("collectGem "+ gem.value);
        TotalGemValue += gem.value;
        gems.Add(gem);
    }
}


public class Player: IHealth
{
    public float healthValue { get; set; }
    public bool healthOver { get; set; }

    public Player(int initialHealth)
    {
        healthOver = false;
        healthValue = initialHealth;
    }

    public void Damange(int damage)
    {
        healthValue -= damage;
        if (healthValue <= 0)
        {
            healthOver = true;
            Debug.Log("Health is over");
        }
    }
}


public class Gem: ICollectable
{
    public bool collected { get; set; }

    public Gem(int val)
    {
        value = val;
    }

    public void Collect()
    {
        collected = true;
    }

    public int value { get; set; }
}


interface IHealth
{
    public bool healthOver { get; set; }
    public float healthValue { get; set; }
    public void Damange(int damage);
}

interface ICollectable
{
    bool collected { get; set; }
    void Collect();

    int value { get; set; }
}