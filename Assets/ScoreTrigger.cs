using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTrigger : MonoBehaviour
{
    public UnityEvent<int> OnScored;
    [SerializeField][Tooltip("The number of the player that scored")] int _playerID;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.GetComponent<Ball>() != null)
        {
            OnScored?.Invoke(_playerID);
        }
    }

}
