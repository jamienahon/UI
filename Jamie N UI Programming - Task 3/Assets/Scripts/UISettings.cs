using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    GameObject gamePlayMenu;
    GameObject mainMenu;
    GameObject audioMenu;
    GameObject graphicsMenu;
    GameObject confirmationMenu;

    public FloatEditor masterVolume;
    public FloatEditor musicVolume;
    public FloatEditor sfxVolume;
    public Settings settings;

    float defaultMasterVolume;

    bool isGameplay = true;
    bool isMenu = false;
    void Awake()
    {
        gamePlayMenu = GameObject.Find("Gameplay");
        mainMenu = GameObject.Find("Menu");
        audioMenu = GameObject.Find("Audio Menu");
        graphicsMenu = GameObject.Find("Graphics Menu");
        confirmationMenu = GameObject.Find("Quit Game Confirmation");

        gamePlayMenu.SetActive(true);
        mainMenu.SetActive(false);
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        confirmationMenu.SetActive(false);
    }

    void Start()
    {
        if(masterVolume)
        {
            masterVolume.floatValue = settings.masterVolume;
            masterVolume.onValueChanged.AddListener((float value) => { settings.masterVolume = value; });
        }
        if (musicVolume)
        {
            musicVolume.floatValue = settings.musicVolume;
            musicVolume.onValueChanged.AddListener((float value) => { settings.musicVolume = value; });
        }
        if (sfxVolume)
        {
            sfxVolume.floatValue = settings.sfxVolume;
            sfxVolume.onValueChanged.AddListener((float value) => { settings.sfxVolume = value; });
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (!audioMenu.activeInHierarchy && !graphicsMenu.activeInHierarchy && !confirmationMenu.activeInHierarchy))
        {
            isGameplay = !isGameplay;
            isMenu = !isMenu;

            gamePlayMenu.SetActive(isGameplay);
            mainMenu.SetActive(isMenu);
        }
    }

    public void OnMasterVolumeChange(float volume)
    {
        settings.masterVolume = volume;
    }

    public void OnMusicVolumeChange(float volume)
    {
        settings.musicVolume = volume;
    }

    public void OnSFXVolumeChange(float volume)
    {
        settings.sfxVolume = volume;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
        confirmationMenu.SetActive(false);
    }

    public void OpenAudioMenu()
    {
        audioMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenGraphicsMenu()
    {
        graphicsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenConfirmtionMenu()
    {
        confirmationMenu.SetActive(true);
    }

    public void GoBack()
    {
        graphicsMenu.SetActive(false);
        audioMenu.SetActive(false);
        confirmationMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
