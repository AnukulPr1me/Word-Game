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

    public string GetWord()
    {
        string word = "";

        for(int i = 0; i < letterContainers.Length; i++)
        {
            word += letterContainers[i].GetLetter().ToString();
        }

        return word;
    }

    public bool IsComplete()
    {
        return CurrentLetterIndex >= 5;
    }
}
