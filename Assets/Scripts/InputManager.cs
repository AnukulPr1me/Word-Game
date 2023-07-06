using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header(" Elements ")]
     [SerializeField] private WordContainer[] wordContainers;


    [Header("Settings")]
    [SerializeField] private int CurrentWordContainerIndex;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        keyboardKey.onKeyPressed += keyPressedCallback;
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
        wordContainers[CurrentWordContainerIndex].Add(letter);

        if (wordContainers[CurrentWordContainerIndex].IsComplete())
        {
           // CheckWord();
            //CurrentWordContainerIndex++;
        }
    }

    public void CheckWord()
    {
        string wordToCheck = wordContainers[CurrentWordContainerIndex].GetWord();
        string secretWord = WordManager.instance.getSecretWord();

        if (string.Equals(secretWord,wordToCheck))
        {
            Debug.Log("Level Complete");
        }
        else
        {
            Debug.Log("Wrong word");
            CurrentWordContainerIndex++;
            Debug.Log(wordToCheck.ToString());
            Debug.Log(secretWord.ToString());

        }
    }
}
