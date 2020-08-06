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

    #region PUBLIC METHODS
    public void UpdateScore(int currentScore)
    {
        _score.text = currentScore.ToString();
    }
    #endregion
}
