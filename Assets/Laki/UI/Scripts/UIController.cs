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
    public static UIController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        currentScreen.TurnOnScreen();
    }

    public AudioMixer mixer;

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ChangeScreen(int index)
    {
        currentScreen.TurnOffScreen();
        ChangeScene(index);
    }

    public void Toggle(bool isTrue)
    {
        if (!isTrue)
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
