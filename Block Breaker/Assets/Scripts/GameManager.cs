using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _blocksInScene = 0;
    // Update is called once per frame
    void Update()
    {
        if(_blocksInScene <= 0)
        {
            SceneLoader.LoadNextScene();
        }
    }
    public void IncreaseBlockCount()
    {
        _blocksInScene++;
    }
    public void DecreaseBlockCount()
    {
        _blocksInScene--;
    }
}
