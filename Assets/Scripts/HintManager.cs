using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private GameObject keyboard;
    private keyboardKey[] keys;


    private void Awake()
    {
       keys = keyboard.GetComponentsInChildren<keyboardKey>(); 
        Debug.Log("we found" + keys.Length + "keys");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyboardHint()
    {
        string secretWord = WordManager.instance.getSecretWord();
        List<keyboardKey> untouchedkeys = new List<keyboardKey>();
        Debug.Log("Keyboard hint Activated");
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i].IsUntouched())
            {
                untouchedkeys.Add(keys[i]);
            }
        }

        List<keyboardKey> t_untouchedKeys = new List<keyboardKey>(untouchedkeys);

        for (int i = 0; i < untouchedkeys.Count; i++)
        {
            if (secretWord.Contains(untouchedkeys[i].GetLetter()))
            {
                t_untouchedKeys.Remove(untouchedkeys[i]);
            }
        }

        if (t_untouchedKeys.Count <= 0)
        {
            return;
        }

        int randomKeyIndex = Random.Range(0, t_untouchedKeys.Count);
        t_untouchedKeys[randomKeyIndex].SetInvalid();

    }

    List<int> letterHintGivenIndices = new List<int>();
    public void LetterHint()
    {
        if(letterHintGivenIndices.Count >= 5)
        {
            Debug.Log(" All hint has been given. ");
            return;
        }

        List<int> letterHintNotGivenIndices = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            if(!letterHintGivenIndices.Contains(i))
            {
                letterHintNotGivenIndices.Add(i);
            }
        }


        WordContainer currentWordContainer = InputManager.instance.GetCurrentWordContainer();
        Debug.Log("Letter hint Activated");

        string secretWord = WordManager.instance.getSecretWord();

        int randomIndex = letterHintNotGivenIndices [Random.Range(0, letterHintNotGivenIndices.Count)];
        letterHintGivenIndices.Add(randomIndex);
        currentWordContainer.AddAsHint(randomIndex, secretWord[randomIndex]);
    }
}
