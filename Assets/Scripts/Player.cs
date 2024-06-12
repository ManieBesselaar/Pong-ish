using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 4;
    Vector2 _currentInput = Vector2.zero;
   
    // Start is called before the first frame update
    Vector3 _newPostion;
    float _newY;
    Vector2 _newPosition;
    float _maxY, _minY;

    void Start()
    {
        float camHeigt = Camera.main.orthographicSize;
        float yOffset = GetComponent<BoxCollider2D>().size.y * transform.localScale.y /2;
        _maxY = Camera.main.transform.position.y + camHeigt - yOffset;
        _minY = Camera.main.transform.position.y - camHeigt + yOffset;
    }

    // Update is called once per frame
    void Update()
    {
       
        _newPosition = new Vector2(transform.position.x,Mathf.Clamp( transform.position.y + 
            (_currentInput.y * _speed * Time.deltaTime),_minY,_maxY));
        transform.position = _newPosition;
    }
    public void OnMove(CallbackContext context)
    {
        _currentInput = context.action.ReadValue<Vector2>();
    }
  
}
