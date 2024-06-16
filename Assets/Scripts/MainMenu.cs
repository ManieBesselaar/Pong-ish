using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void StartSinglePlayer()
    {
        AppManager.Instance.StartSinglePlayerGame();
    }
    public void StartMultiplayerGame()
    {
        AppManager.Instance.StartMultiPlayerGame();
    }
    public void Quit()
    {
        AppManager.Instance.QuitApp();
    }
}
