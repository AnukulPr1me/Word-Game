using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{

    public static WordManager instance;

    [Header(" Elements ")]
    [SerializeField] private string secretWord;
    [SerializeField] private TextAsset wordsText;
    private string words;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        words = wordsText.text;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetNewSecretWord();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getSecretWord()
    {
        return secretWord;
    }

    private void SetNewSecretWord()
    {
        Debug.Log("String Length : " + words.Length);
        int wordCount = (words.Length + 2) / 7;

        int wordIndex = Random.Range(0, wordCount);

        int wordStartIndex = wordIndex * 7;

        secretWord = words.Substring(wordStartIndex, 5).ToUpper();
    }
}
