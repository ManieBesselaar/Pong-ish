using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] Transform _ball;
    Player _playerScript;
    float _maxY, _minY;
    [SerializeField] float _speed = 4;
    float _newY;
    Vector2 _newPosition;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        float camHeigt = Camera.main.orthographicSize;
        float yOffset = GetComponent<BoxCollider2D>().size.y * transform.localScale.y / 2;
        _maxY = Camera.main.transform.position.y + camHeigt - yOffset;
        _minY = Camera.main.transform.position.y - camHeigt + yOffset;
    }

    // Update is called once per frame
    void Update()
    {
      /*  _newPosition = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y +
           ( _speed * Time.deltaTime), _minY, _maxY));
        transform.position = _newPosition;
      */
      _newPosition = new Vector2(transform.position.x,Mathf.Clamp( _ball.position.y,_minY,_maxY));
        transform.position = Vector2.MoveTowards(transform.position, _newPosition, _speed * Time.deltaTime);    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audioSource.Play();
    }
}
