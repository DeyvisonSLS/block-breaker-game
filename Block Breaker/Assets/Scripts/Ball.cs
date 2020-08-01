using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle _paddle;
    private Vector3 _initialPos;
    private Vector2  _paddlePosDifference;
    private Rigidbody2D _rigidBody2D;
    [SerializeField]
    private AudioClip[] _ballAudioClips;
    private AudioSource _ballAudioSource;
    private bool hasLaunched = false;
    [SerializeField]
    private float xPush;
    [SerializeField]
    private float yPush;
    // Start is called before the first frame update
    void Start()
    {
        xPush = 0.0f;
        yPush = 10.0f;
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _initialPos = transform.position;
        _paddle = GameObject.FindWithTag("Paddle").GetComponent<Paddle>();
        _paddlePosDifference = transform.position - _paddle.transform.position; // axis.y = 2 - padle.axis.y = 1 = 1 (distance between one another)
        _ballAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasLaunched)
        {
            StickBallToPaddle();
        }
        if(_rigidBody2D.velocity == Vector2.zero)
        {
            LaunchBallOnClick();
        }
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {

        if(hasLaunched)
        {
            _ballAudioSource.PlayOneShot(_ballAudioClips[Random.Range(0, _ballAudioClips.Length)]);
        }
    }

    private void LaunchBallOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasLaunched = true;
            _rigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(_paddle.transform.position.x, _paddle.transform.position.y);
        transform.position = paddlePos + _paddlePosDifference;  
    }
}
