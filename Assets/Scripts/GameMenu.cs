using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    public void ResumeGame()
    {
        _gameManager.GameMenuShow(false);
    }
    public void Quit()
    {
        AppManager.Instance.LoadSceneByName("EndScene");
    }
    public void RestartGame()
    {
        _gameManager.RestartGame();
        _gameManager.GameMenuShow(false);
    }
}
