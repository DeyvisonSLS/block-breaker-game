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
    #endregion

    #region PROPERTIES
    [SerializeField]
    public int BlocksInScene { get; private set; } = 0;
    #endregion

    #region MONOBEHAVIOUR
    void Update()
    {
        Time.timeScale = _gameSpeed;
        Time.fixedDeltaTime = _myFixedDeltaTime * Time.timeScale;
    }
    #endregion
    
    #region PUBLIC METHODS
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
