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
        if (wordContainers[CurrentWordContainerIndex].IsComplete())
        {
            CurrentWordContainerIndex++;
        }

        wordContainers[CurrentWordContainerIndex].Add(letter);
    }
}
