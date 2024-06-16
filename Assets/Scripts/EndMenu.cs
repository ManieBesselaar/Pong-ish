using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void Quit()
    {
        AppManager.Instance.QuitApp();
    }
    public void MainMenuGo()
    {
        AppManager.Instance.LoadSceneByName("Menu");
    }
}
