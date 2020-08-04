using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region FIELDS
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float _gameSpeed = 1.0f;
    private float _myFixedDeltaTime = 0.02f;
    [SerializeField]
    private int _score = 0;
    #endregion

    #region PROPERTIES
    [SerializeField]
    public int BlocksInScene { get; private set; } = 0;
    public int Score 
    { 
        get
        {
            return _score;
        }
        private set
        {
            _score = value;
        }
    }
    #endregion

    #region MONOBEHAVIOUR
    void Update()
    {
        Time.timeScale = _gameSpeed;
        Time.fixedDeltaTime = _myFixedDeltaTime * Time.timeScale;
    }
    #endregion
    
    #region PUBLIC METHODS
    public void AddPointsToScore(int points)
    {
        Score += points;
    }
    #endregion

    #region PRIVATE METHODS
    public void IncreaseBlockCount()
    {
        BlocksInScene++;
    }
    public void DecreaseBlockCount()
    {
        BlocksInScene--;
        if(BlocksInScene <= 0)
        {
            SceneLoader.LoadNextScene();
        }
    }
    #endregion
}
