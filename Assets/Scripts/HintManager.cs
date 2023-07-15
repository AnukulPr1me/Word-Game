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
        Debug.Log("Keyboard hint Activated");
    }

    public void LetterHint()
    {
        Debug.Log("Letter hint Activated");
    }
}
