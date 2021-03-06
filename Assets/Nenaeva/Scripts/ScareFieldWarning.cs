﻿using UnityEngine;

public class ScareFieldWarning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Triggering warning sound!!!");
            GameManager.Instance.soundHandler.snakeWarning.Play();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("You are now safe!");
        }
    }
}