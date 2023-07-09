using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private TextMeshPro letter;
    [SerializeField] private SpriteRenderer letterContainer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        letter.text = "";
        letterContainer.color = Color.white;
    }

    public void SetLetter(char letter)
    {
        this.letter.text = letter.ToString();
    }

    public char GetLetter()
    {
        return letter.text[0];
    }

    public void SetValid()
    {
        letterContainer.color = Color.green;
    }


    public void SetPotential()
    {
        letterContainer.color = Color.yellow;

    }

    public void SetInvalid()
    {
        letterContainer.color= Color.gray;
    }
    
}
