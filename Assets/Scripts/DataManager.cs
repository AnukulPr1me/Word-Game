using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;


    [Header(" Data ")]
    private int coins;
    private int score;
    private int bestscore;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
    }

    public void RemoveCoins(int Amount)
    {
        coins -= Amount;
        coins = Mathf.Max(coins, 0);
        SaveData();
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
