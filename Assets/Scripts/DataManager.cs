using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{

    public static DataManager instance;


    [Header(" Data ")]
    private int coins;
    private int score;
    private int bestscore;


    [Header(" Events ")]
    public static Action onCoinsUpdate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadData();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int Amount)
    {
        coins += Amount;
        SaveData();
        onCoinsUpdate?.Invoke();
    }

    public void RemoveCoins(int Amount)
    {
        coins -= Amount;
        coins = Mathf.Max(coins, 0);
        SaveData();

        onCoinsUpdate?.Invoke();
    }

    public void IncreaseScore(int Amount)
    {
        score += Amount;

        if (score > bestscore)
        {
            bestscore = score;
        }
        SaveData();
    }

    public void ResetScore()
    {
        score = 0;
        SaveData();
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetBestScore()
    {
        return bestscore;
    }

    private void LoadData()
    {
        coins = PlayerPrefs.GetInt("coins");
        score = PlayerPrefs.GetInt("score");
        bestscore = PlayerPrefs.GetInt("bestscore");
    }

    private void SaveData()
    {
       PlayerPrefs.SetInt("coins", coins);
       PlayerPrefs.SetInt("score", score);
       PlayerPrefs.SetInt("bestscore", bestscore);
    }
}
