using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    public virtual void TurnOnScreen() { }
    public virtual void TurnOffScreen() 
    {
        gameObject.SetActive(false);
    }
}
