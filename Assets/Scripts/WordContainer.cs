using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordContainer : MonoBehaviour
{

    [Header(" Elements ")]
    private LetterContainer[] letterContainers;
    // Start is called before the first frame update

    [Header(" Settings")]
    private int CurrentLetterIndex;


    private void Awake()
    {
        letterContainers = GetComponentsInChildren<LetterContainer>();
        //Initialize();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        for(int i = 0; i < letterContainers.Length; i++)
        {
            letterContainers[i].Initialize();
        }
    }

    public void Add(char letter)
    {
        letterContainers[CurrentLetterIndex].SetLetter(letter);
        CurrentLetterIndex++;
    }

    public bool RemoveLetter()
    {
        if(CurrentLetterIndex <= 0)
        {
            return false;
        }
        CurrentLetterIndex--;
        letterContainers[CurrentLetterIndex].Initialize();
        return true;
    }
    public string GetWord()
    {
        string word = "";

        for(int i = 0; i < letterContainers.Length; i++)
        {
            word += letterContainers[i].GetLetter().ToString();
        }

        return word;
    }

    public void colorize(string secretWord)
    {

        List<char> chars = new List<char>(secretWord.ToCharArray());


        for (int i = 0;i < letterContainers.Length;i++)
        {
            char letterToCheck = letterContainers[i].GetLetter();

            if (letterToCheck == secretWord[i])
            {
                letterContainers[i].SetValid();
                chars.Remove(letterToCheck);

            }
            else if (secretWord.Contains(letterToCheck))
            {

                letterContainers[i].SetPotential();
                chars.Remove(letterToCheck);
            }
            else
            {
                letterContainers[i].SetInvalid();
            }
        }

    }

    public bool IsComplete()
    {
        return CurrentLetterIndex >= 5;
    }

}
