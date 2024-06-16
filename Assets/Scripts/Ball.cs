using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
  [SerializeField]  Rigidbody2D _rb;
    [SerializeField] float _forceMagnitude;
    Vector2 _direction;
    [SerializeField] Vector3 _spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
      // LaunchBall();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
       ResetBall();
        LaunchBall();
    }
   public void LaunchBall()
    {
        _rb.velocity = Vector2.zero;
        _direction = new Vector2(1, Random.Range(-.3f, .3f));
        _rb.AddForce(_direction * _forceMagnitude);
    }
    public void ResetBall()
    {
        _rb.transform.position = _spawnPosition;
    }
}
