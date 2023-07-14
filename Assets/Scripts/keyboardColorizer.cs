using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardColorizer : MonoBehaviour
{

    public static keyboardColorizer Instance;
    [Header(" Elements ")]
    private keyboardKey[] keys;


    private void Awake()
    {
        keys = GetComponentsInChildren<keyboardKey>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:
                Initialize();
                break;

            case GameState.LevelComplete:

                break;
        }
    }

    private void Initialize()
    {
        for(int i = 0; i < keys.Length; i++)
        {
            keys[i].Initialize();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Colorize(string secretWord, string wordToCheck)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            char keyletter = keys[i].GetLetter();
            for (int j = 0; j < wordToCheck.Length; j++)
            {
                if (keyletter != wordToCheck[j])
                {
                    continue;
                }


                if (keyletter == secretWord[j])
                {
                    keys[i].SetValid();
                }
                else if(secretWord.Contains(keyletter))
                {
                    keys[i].SetPotential();
                }
                else
                {
                    keys[i].SetInvalid();
                }
            }

        }


    }
    
}
