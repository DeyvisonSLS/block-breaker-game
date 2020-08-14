using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private GameManager _gameManager;
    private UIManager _uiManager;

    #region MONOBEHAVIOUR
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _uiManager = FindObjectOfType<UIManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_gameManager != null)
        {
            _gameManager.Destroy();
        }
        SceneLoader.LoadScene("Play Again");
        Destroy(other);
    }
    #endregion
}
