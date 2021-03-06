﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region FIELDS
    [Range(0.0f, 5.0f)]
    [SerializeField]
    private float _gameSpeed = 1.0f;
    private float _myFixedDeltaTime = 0.02f;
    [SerializeField]
    private int _score = 0;
    private int _blocksInScene = 0;
    [SerializeField]
    private bool _autoPlay = false;
    private UIManager _uiManager;
    #endregion

    #region PROPERTIES
    public int BlocksInScene 
    {
        get
        {
            return _blocksInScene;
        }
        private set
        {
            _blocksInScene = value;
        } 
    }
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
    void Awake()
    {
        int gameManagerCount = FindObjectsOfType<GameManager>().Length;
        if(gameManagerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        _uiManager = FindObjectOfType<UIManager>();
    }
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
        Debug.Log("Ponto adicionado!");
        // if(_uiManager != null)
        _uiManager.UpdateScore(Score);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayOn()
    {
        return _autoPlay;
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
