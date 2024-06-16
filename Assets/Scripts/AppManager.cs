using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
  public static  AppManager Instance { get; private set; }
public enum GameType
    {
        SINGLE_PLAYER,
        MULTI_PLAYER
    }
public GameType CurrentGameType { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartSinglePlayerGame()
    {
        CurrentGameType = GameType.SINGLE_PLAYER;
        LoadSceneByName("GameScene");
    }
    public void StartMultiPlayerGame()
    {
        CurrentGameType = GameType.MULTI_PLAYER;
        LoadSceneByName("GameScene");
    }
  
   
    public void QuitApp()
    {

    # if UNITY_EDITOR 
        EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
