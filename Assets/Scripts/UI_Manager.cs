using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [Header(" Elements ")]
    [SerializeField] private CanvasGroup menuCG;
    [SerializeField] private CanvasGroup gameCG;
    [SerializeField] private CanvasGroup levelCompleteCG;
    [SerializeField] private CanvasGroup gameoverCG;
    

    [Header(" Menu Elements")]
    [SerializeField] private TextMeshProUGUI menuCoins;
    [SerializeField] private TextMeshProUGUI menuBestScore;

    [Header("level Complete Elements")]
    [SerializeField] private TextMeshProUGUI levelCompleteCoins;
    [SerializeField] private TextMeshProUGUI levelCompleteSecretword;
    [SerializeField] private TextMeshProUGUI levelCompleteScore;
    [SerializeField] private TextMeshProUGUI levelCompleteBestScore;

    [Header(" Gameover Elements")]
    [SerializeField] private TextMeshProUGUI gameoverCoins;
    [SerializeField] private TextMeshProUGUI gameoverSecretword;
    [SerializeField] private TextMeshProUGUI gameoverBestScore;


    [Header(" Game Elements")]
    [SerializeField] private TextMeshProUGUI gameScore;
    [SerializeField] private TextMeshProUGUI gameCoins;
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
        showMenu();
        HideGame();
        HideLevelComplete();
        HideGameover();
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:

                showMenu();
                HideGame();

                break;

            case GameState.Game:
                ShowGame();
                hideMenu();
                HideLevelComplete();
                HideGameover();
                break;

            case GameState.LevelComplete:
                ShowLevelComplete();
                HideGame();
                break;

            case GameState.GameOver:
                ShowGameover();
                HideGame();
                 break;
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }

    private void showMenu()
    {
        menuCoins.text = DataManager.instance.GetCoins().ToString();
        menuBestScore.text = DataManager.instance.GetBestScore().ToString();

        ShowCG(menuCG);
    }

    private void hideMenu()
    {
        HideCG(menuCG);
    }
    private void ShowGame()
    {
        gameCoins.text = DataManager.instance.GetCoins().ToString();
        gameScore.text = DataManager.instance.GetScore().ToString();

        ShowCG(gameCG);
    }

    private void HideGame()
    {
        HideCG(gameCG);
    }

    private void ShowLevelComplete()
    {
        levelCompleteCoins.text = DataManager.instance.GetCoins().ToString();
        levelCompleteSecretword.text = WordManager.instance.getSecretWord();
        levelCompleteScore.text = DataManager.instance.GetScore().ToString();
        levelCompleteBestScore.text = DataManager.instance.GetBestScore().ToString();
        ShowCG(levelCompleteCG);
    }

    private void HideLevelComplete()
    {
        HideCG(levelCompleteCG);
    }

    private void ShowGameover()
    {
        gameoverCoins.text = DataManager.instance.GetCoins().ToString();
        gameoverSecretword.text = WordManager.instance.getSecretWord();
        gameoverBestScore.text = DataManager.instance.GetBestScore().ToString();

        ShowCG(gameoverCG);
    }

    private void HideGameover()
    {
        HideCG(gameoverCG);
    }

    private void ShowCG(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    private void HideCG(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
