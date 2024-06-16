using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField] int _winScore = 10;
    [SerializeField] TextMeshProUGUI _scoreText1, _scoreText2;
    int _p1Score = 0,_p2Score = 0;
    [SerializeField] ScoreTrigger _scoreTrigger1,_scoreTrigger2;
    [SerializeField] GameObject _aiPlayer;
    [SerializeField] Ball _ball;
    [SerializeField] PlayerJoinDetector _playerJoinDetector;
    [SerializeField] GameObject _gameMenu;
    AudioSource _audiosource;
    [SerializeField] AudioClip _startGameClip, _pointScoredClip;
    // Start is called before the first frame update
    void Start()
    {
        if (AppManager.Instance.CurrentGameType == AppManager.GameType.MULTI_PLAYER)
        {
            _aiPlayer.SetActive(false);
            
        }
        GameMenuShow(false);
        _scoreTrigger1.OnScored.AddListener(Score);
        _scoreTrigger2.OnScored.AddListener(Score);
        _playerJoinDetector.OnAllPlayersJoined.AddListener(PlayStartSound);
        _audiosource = GetComponent<AudioSource>();
    }

    private void Score(int playerNumber)
    {
        Debug.Log("Player " +  playerNumber + " has scored ");
        PlayScoreSound();
        if(playerNumber == 1)
        {
            _p1Score++;
            _scoreText1.text = _p1Score.ToString();
        }
        else
        {
            _p2Score++;
            _scoreText2.text = _p2Score.ToString();
        }
        if (_p1Score >= _winScore ||  _p2Score >= _winScore)
        {
            Debug.Log("Someone won");
            _p1Score = 0;
            _p2Score = 0;
        }
    }
    public void LaunchBall()
    {
        _ball.LaunchBall();
    }
    public void GameMenuShow(bool isActive)
    {
        _gameMenu.SetActive(isActive);
        if(isActive )
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    internal void RestartGame()
    {
        PlayStartSound();
        _p1Score = 0;
        _p2Score = 0;
        _scoreText1.text = _p1Score.ToString();
        _scoreText2.text = _p2Score.ToString();
        _ball.ResetBall();
        _ball.LaunchBall();
    }

    private void PlayScoreSound()
    {
        _playerJoinDetector.OnAllPlayersJoined.RemoveListener(PlayStartSound);
        _audiosource.clip = _startGameClip;
        _audiosource.Play();
    }
    private void PlayStartSound()
    {

        _audiosource.clip = _pointScoredClip;
        _audiosource.Play();
    }
}
