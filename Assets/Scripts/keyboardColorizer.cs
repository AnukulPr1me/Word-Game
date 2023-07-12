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
