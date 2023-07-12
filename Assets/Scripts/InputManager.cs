using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private WordContainer[] wordContainers;

    [SerializeField] private Button tryButton;
    [SerializeField] private keyboardColorizer keyboardColorizer;

    [Header("Settings")]
    [SerializeField] private int CurrentWordContainerIndex;

    private bool canAddLeter = true;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        keyboardKey.onKeyPressed += keyPressedCallback;
    }


    private void OnDestroy()
    {
        keyboardKey.onKeyPressed -= keyPressedCallback;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        for(int i = 0; i < wordContainers.Length; i++)
        {
            wordContainers[i].Initialize();

        }

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
            canAddLeter = true;
            

        }
    }

    public void BackSpacePressCallback()
    {
        bool RemoveLetter = wordContainers[CurrentWordContainerIndex].RemoveLetter();
        if(RemoveLetter)
        {
            DisableTryButton() ;
        }

        canAddLeter = true;
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
        GameManager.instance.SetGameState(GameState.LevelComplete);

    }
}   
