using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [Header(" Element ")]
    [SerializeField] private Image soundImage;
    [SerializeField] private Image hapticsImage;

    [Header("Settings")]
    private bool soundState;
    private bool hapticsState;
    // Start is called before the first frame update
    void Start()
    {
        LoadStates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundsButtonCallback()
    {
        soundState = !soundState;
        UpdateSoundState();
        SaveStates();
    }

    private void UpdateSoundState()
    {
        if (soundState)
        {
            EnableSounds();
        }
        else
        {
            DisableSounds();
        }
    }

    private void EnableSounds()
    {
        //SoundManager.instance.EnableSounds();
        soundImage.color = Color.white;
    }

    private void DisableSounds()
    {
        //SoundManager.instance.DisableSounds();
        soundImage.color = Color.gray;
    }

    public void HapticsButtonCallback()
    {
        hapticsState = !hapticsState;
        UpdateHapticsState();
        SaveStates();
    }

    private void UpdateHapticsState()
    {
        if (hapticsState)
        {
            EnableHaptics();
        }
        else
        {
            DisableHaptics();
        }
    }

    private void EnableHaptics()
    {
        //HapticsManager.instance.EnableHaptics();
        hapticsImage.color = Color.white;
    }

    private void DisableHaptics()
    {
        //HapticsManager.instance.DisableHaptics();
        hapticsImage.color = Color.gray;
    }


    private void LoadStates()
    {
        soundState = PlayerPrefs.GetInt("sounds", 1) == 1;
        hapticsState = PlayerPrefs.GetInt("haptics", 1) == 1;

        UpdateSoundState();

        UpdateHapticsState();
    }

    private void SaveStates()
    {
        PlayerPrefs.SetInt("sounds", soundState ? 1 : 0);
        PlayerPrefs.SetInt("haptics", hapticsState ? 1 : 0);
    }
}
