using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public UIScreen currentScreen;
    public UIScreen mainMenu;
    public UIScreen inGame;
    public static UIController Instance;
    public bool isPressed=false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public AudioMixer mixer;

    public void ChangeScreen(UIScreen screen)
    {
        currentScreen.TurnOffScreen();
        screen.gameObject.SetActive(true);
        screen.TurnOnScreen();
        currentScreen = screen;
    }

    public void Toggle(bool isTrue)
    {
        if (isTrue)
        {
            mixer.SetFloat("Music", 10);
        }
        else
        {
            mixer.SetFloat("Music", -80);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
