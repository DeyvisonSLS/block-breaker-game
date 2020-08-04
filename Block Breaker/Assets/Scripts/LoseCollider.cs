﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    #region MONOBEHAVIOUR
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneLoader.LoadScene("Play Again");
        Destroy(other);
    }
    #endregion
}
