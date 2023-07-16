using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [Header(" Elements ")]
    [SerializeField] private WordContainer[] wordContainers;

    [SerializeField] private Button tryButton;
    [SerializeField] private keyboardColorizer keyboardColorizer;

    [Header("Settings")]
    [SerializeField] private int CurrentWordContainerIndex;
    private bool shouldReset;

    private bool canAddLeter = true;


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
    }


    public static Action OnLetterAdded;
    public static Action OnLetterRemoved;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        keyboardKey.onKeyPressed += keyPressedCallback;
        GameManager.onGameStateChanged += GameStateChangedCallback;
        // DisableTryButton();
    }


    private void OnDestroy()
    {
        keyboardKey.onKeyPressed -= keyPressedCallback;
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:

                if(shouldReset)
                {
                    Initialize();
                }
                    
                break;

            case GameState.LevelComplete:
                shouldReset = true;
                break;

            case GameState.GameOver:
                shouldReset = true;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        CurrentWordContainerIndex = 0;
        canAddLeter = true;
        DisableTryButton();
        for(int i = 0; i < wordContainers.Length; i++)
        {
            wordContainers[i].Initialize();

        }
        shouldReset = false;
    }

    private void keyPressedCallback(char letter)
    {
        if (!canAddLeter)
        {
            return;
        }
        wordContainers[CurrentWordContainerIndex].Add(letter);

        if (wordContainers[CurrentWordContainerIndex].IsComplete())
        {
          
            canAddLeter = false;
            EnableTryButton();
           // CheckWord();
            //CurrentWordContainerIndex++;
        }

        OnLetterAdded?.Invoke();
    }

    public void CheckWord()
    {
        string wordToCheck = wordContainers[CurrentWordContainerIndex].GetWord();
        string secretWord = WordManager.instance.getSecretWord();

        wordContainers[CurrentWordContainerIndex].colorize(secretWord);

        keyboardColorizer.Colorize(secretWord, wordToCheck);

        if (string.Equals(secretWord,wordToCheck))
        {
            Debug.Log("Level Complete");
            SetLevelComplete();
        }
        else
        {
            Debug.Log("Wrong word");
            CurrentWordContainerIndex++;
            DisableTryButton();

            if (CurrentWordContainerIndex >= wordContainers.Length)
            {
                Debug.Log("Game Over");
                DataManager.instance.ResetScore();
                GameManager.instance.SetGameState(GameState.GameOver);
            }
            else
            {
                
                canAddLeter = true;
            }
            

        }
    }

    public void BackSpacePressCallback()
    {
        if (!GameManager.instance.IsGameState())
        { return; }
        bool RemoveLetter = wordContainers[CurrentWordContainerIndex].RemoveLetter();
        if(RemoveLetter)
        {
            DisableTryButton() ;
        }

        canAddLeter = true;

        OnLetterRemoved?.Invoke();
    }


    private void EnableTryButton()
    {
        tryButton.interactable = true;
    }
    private void DisableTryButton()
    {
        tryButton.interactable = false;
    }

    private void SetLevelComplete()
    {
        UpdateData();
        GameManager.instance.SetGameState(GameState.LevelComplete);

    }

    private void UpdateData()
    {
        int scoreToAdd = 6 - CurrentWordContainerIndex;
        DataManager.instance.IncreaseScore(scoreToAdd);
        DataManager.instance.AddCoins(scoreToAdd * 3);
    }

    public WordContainer GetCurrentWordContainer()
    {
        return wordContainers[CurrentWordContainerIndex];
    }
}   
