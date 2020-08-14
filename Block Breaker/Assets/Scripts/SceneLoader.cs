using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameManager _gameManager;

    #region MONOBEHAVIOR
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    #endregion

    #region PUBLIC METHODS
    public static void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentSceneIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadStartScene()
    {
        if(_gameManager != null)
        {
            _gameManager.Destroy();
        }
        SceneManager.LoadScene(0);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
