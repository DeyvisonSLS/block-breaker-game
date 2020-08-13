using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region FIELDS
    [SerializeField]
    private TextMeshProUGUI _score;
    #endregion

    #region MONOBEHAVIOUR
    #endregion
    
    #region PUBLIC METHODS
    public void UpdateScore(int currentScore)
    {
        // if(_score != null)
        _score.text = currentScore.ToString();
        Debug.Log("String score updated");
    }
    public void HUDView(bool visibility)
    {
        gameObject.SetActive(visibility);
    }
    #endregion
}
