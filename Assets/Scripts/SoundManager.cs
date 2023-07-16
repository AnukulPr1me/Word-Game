using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [Header(" Sound ")]
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource letterAddedSound;
    [SerializeField] private AudioSource LetterRemovedSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;


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
    }
    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnLetterAdded += PlayLetterAddedSound;
        InputManager.OnLetterRemoved += PlayLetterRemovedSound;

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        InputManager.OnLetterAdded -= PlayLetterAddedSound;
        InputManager.OnLetterRemoved -= PlayLetterRemovedSound;

        GameManager.onGameStateChanged -= GameStateChangedCallback;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.LevelComplete:
                levelCompleteSound.Play();
                break;

            case GameState.GameOver:
                gameOverSound.Play();
                break;
        }
   
    }

    private void PlayLetterAddedSound()
    {
        letterAddedSound.Play();
    }

    private void PlayLetterRemovedSound()
    {
        LetterRemovedSound.Play();
    }

    public void playButtonSound()
    {
        buttonSound.Play();
    }

    public void EnableSounds()
    {
        buttonSound.volume = 1;
        letterAddedSound.volume = 1;
        LetterRemovedSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;

    }

    public void DisableSounds()
    {
        buttonSound.volume = 0;
        letterAddedSound.volume = 0;
        LetterRemovedSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
    }
}
