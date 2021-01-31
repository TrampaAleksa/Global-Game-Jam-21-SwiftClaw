using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainMenuScreen : UIScreen
{
    public float time;
    public GameObject obj;
    public GameObject obj1;
    public override void TurnOnScreen()
    {
        base.TurnOnScreen();
    }
    public override void TurnOffScreen()
    {
        LeanTween.moveY(obj, 540, time);
        LeanTween.moveY(obj1, 540, time);
    }
}
