using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _winScore = 10;
    [SerializeField] TextMeshProUGUI _scoreText1, _scoreText2;
    int _p1Score = 0,_p2Score = 0;
    [SerializeField] ScoreTrigger _scoreTrigger1,_scoreTrigger2;

    // Start is called before the first frame update
    void Start()
    {
        _scoreTrigger1.OnScored.AddListener(Score);
        _scoreTrigger2.OnScored.AddListener(Score);
    }

    private void Score(int playerNumber)
    {
        Debug.Log("Player " +  playerNumber + " has scored ");
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

   
}
