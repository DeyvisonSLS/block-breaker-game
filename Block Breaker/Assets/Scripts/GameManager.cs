using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _blocksInScene = 0;
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float _gameSpeed = 1.0f;
    private float fixedDeltaTime;
    void Awake()
    {
        this.fixedDeltaTime = 0.02f;
        Debug.Log("fixedDeltaTime on awake is: " + this.fixedDeltaTime);
    }
    void Update()
    {
        // Debug.Log("deltaTime: " + Time.deltaTime);
        // Debug.Log("fixedDeltaTime: " + Time.fixedDeltaTime);
        Time.timeScale = _gameSpeed;
        // Time.maximumDeltaTime =  _gameSpeed;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
    public void IncreaseBlockCount()
    {
        _blocksInScene++;
    }
    public void DecreaseBlockCount()
    {
        _blocksInScene--;
        if(_blocksInScene <= 0)
        {
            SceneLoader.LoadNextScene();
        }
    }
}
