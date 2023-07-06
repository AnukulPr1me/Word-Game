using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class keyboardKey : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI letterText;

    [Header(" Event ")]
    public static Action<char> onKeyPressed;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SendKeyPressedEvent);
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private void SendKeyPressedEvent()
    {
        onKeyPressed?.Invoke(letterText.text[0]);
    }
}
