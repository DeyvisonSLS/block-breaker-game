using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region FIELDS
    //  Force values that the ball is launched
    [SerializeField]
    private float xPush;
    [SerializeField]
    private float yPush;
    // The paddle about the ball
    private Paddle _paddle;
    //  Difference between the center of the paddle an its top, where the ball is.
    private Vector2  _paddlePosDifference;
    private Rigidbody2D _ballRigidBody2D;
    //  Sounds of click when the ball collides. They are ramdomly selected.
    [SerializeField]
    private AudioClip[] _ballAudioClips = null;
    //  The game audio source placed on the main camera
    private AudioSource _ballAudioSource;
    [SerializeField]
    private float _randomFactor = 0.05f;
    #endregion

    #region PROPERTIES
    //  After all, it was already launched or not?
    public bool HasLaunched { get; private set; } = false;
    #endregion

    #region MONOBEHAVIOUR
    void Start()
    {
        xPush = 0.0f;
        yPush = 10.0f;
        _ballRigidBody2D = GetComponent<Rigidbody2D>();
        _paddle = GameObject.FindWithTag("Paddle").GetComponent<Paddle>();
        _paddlePosDifference = transform.position - _paddle.transform.position;
        _ballAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(!HasLaunched)
        {
            StickBallToPaddle();
        }
        if(_ballRigidBody2D.velocity == Vector2.zero)
        {
            LaunchBallOnClick();
        }
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, _randomFactor), Random.Range(0, _randomFactor));
        if(HasLaunched)
        {
            _ballAudioSource.PlayOneShot(_ballAudioClips[Random.Range(0, _ballAudioClips.Length)]);
            _ballRigidBody2D.velocity += velocityTweak;
        }
    }
    #endregion

    #region PUBLIC METHODS
    #endregion

    #region PRIVATE METHODS
    private void LaunchBallOnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HasLaunched = true;
            _ballRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }
    private void StickBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(_paddle.transform.position.x, _paddle.transform.position.y);
        //  Assigns the paddle position plus .574 (difference it takes from pivot in the paddle center to its top) in axis.y.
        transform.position = paddlePos + _paddlePosDifference;
    }
    #endregion
}
