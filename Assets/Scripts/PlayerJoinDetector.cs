using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;



public class PlayerJoinDetector : MonoBehaviour
{
    int _numberOfPlayers = 0;
   [SerializeField] Transform[] _playerStartPositions;
    PlayerInputManager _playerInputManager;
    int _numberOfAllowedPlayers = 1;
   public UnityEvent OnAllPlayersJoined;
    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        if(AppManager.Instance.CurrentGameType == AppManager.GameType.MULTI_PLAYER)
        {
            _numberOfAllowedPlayers = _playerInputManager.maxPlayerCount;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if (_numberOfAllowedPlayers <= _numberOfPlayers)

        {
            Destroy(playerInput.gameObject); 
            return;
       }
     
        playerInput.transform.position = _playerStartPositions[_numberOfPlayers].position;
        // playerInput.transform.localPosition = Vector3.zero;


        if (_numberOfPlayers > 0)
        {
            playerInput.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
          //  FindObjectOfType<PlayerAI>().gameObject.SetActive(false);
        }
            _numberOfPlayers++;
       
            if(_numberOfPlayers == _numberOfAllowedPlayers) 
        {
            OnAllPlayersJoined?.Invoke();
        }
       

    }

}
