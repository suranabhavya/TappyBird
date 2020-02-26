using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : MonoBehaviour
{
    
    public void ExitButton()
    {
        GameManager.instance.playSoundButtonClick();
        Application.Quit();
        GameManager.instance.playSoundButtonOver();
    }
}
