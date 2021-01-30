using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorialObject;
    public GameObject inGameObject;
    public GameObject tryAgainObject;
    public GameObject congratsObject;
    public GameObject currentObject;
    public GameObject pauseObject;
    public static UIController Instance;
    public bool isPressed=false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public AudioMixer mixer;

    public void ButtonClick(GameObject activeObject)
    {
        if (currentObject != null)
            currentObject.SetActive(false);
        currentObject = activeObject;
        currentObject.SetActive(true);
    }

    public void Pause(bool isActive)
    {
        PauseTime(isActive);
        pauseObject.SetActive(isActive);
    }
    public void PauseTime(bool isActive)
    {
        if (isActive)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
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

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentObject.name == inGameObject.name)
            {
                if (!isPressed)
                {
                    isPressed = true;
                    Pause(true);
                }
                else
                {
                    isPressed = false;
                    Pause(false);
                }
            }

        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
